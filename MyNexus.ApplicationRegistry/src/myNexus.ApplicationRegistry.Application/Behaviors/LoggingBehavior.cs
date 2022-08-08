using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Application.Behaviors
{
    /// <summary>
    ///   A behavior used to log requests and any exceptions that occur.
    /// </summary>
    /// <typeparam name="TRequest">The type of request.</typeparam>
    /// <typeparam name="TResponse">The type of response.</typeparam>
    internal class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        ///   Logs the current request, as well as any exception that may occur.
        /// </summary>
        /// <param name="request">The request to authorize.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <param name="next">The next request in the pipeline.</param>
        /// <returns>The response from the request handler.</returns>
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var dictionary = new Dictionary<string, object>
            {
                { "CorrelationId", (request as IAmCorrelatable)?.CorrelationId.Value ?? Guid.Empty },
            };

            using (logger.BeginScope(dictionary))
            {
                try
                {
                    logger.LogTrace(
                        "[APPL]==> {Request}",
                        TypeNameHelper.GetTypeDisplayName(typeof(TRequest), false));

                    var response = await next();

                    if (response != null)
                    {
                        var args = new object[]
                        {
                            TypeNameHelper.GetTypeDisplayName(typeof(TRequest), false),
                            TypeNameHelper.BuiltInTypeNames.ContainsKey(typeof(TResponse)) || response is Guid
                                ? response.ToString()
                                : TypeNameHelper.GetTypeDisplayName(typeof(TResponse), false),
                        };

                        logger.LogDebug(
                            "[APPL]==> {Request}\n[APPL]<== OK: {Response}", args[0], args[1]);
                    }
                    else
                    {
                        logger.LogDebug(
                            "[APPL]==> {Request}\n[APPL]<== OK",
                            TypeNameHelper.GetTypeDisplayName(typeof(TRequest), false));
                    }

                    return response;
                }
                catch (AggregateException e)
                {
                    logger.LogError(
                        e.InnerException.Demystify(),
                        "[APPL]==> {Request}\n[APPL]<== ERROR {StatusCode}: {Message}",
                        TypeNameHelper.GetTypeDisplayName(typeof(TRequest), false),
                        GetStatusCode(e.InnerException),
                        e.InnerException.Message);

                    throw;
                }
                catch (Exception e)
                {
                    logger.LogError(
                        e.Demystify(),
                        "[APPL]==> {Request}\n[APPL]<== ERROR {StatusCode}: {Message}",
                        TypeNameHelper.GetTypeDisplayName(typeof(TRequest), false),
                        GetStatusCode(e),
                        e.Message);

                    throw;
                }
            }
        }

        private int GetStatusCode(Exception e)
        {
            return (e as Exceptions.BaseApplicationException)?.StatusCode
                ?? (e as Domain.Exceptions.BaseDomainException)?.StatusCode
                ?? (e as Data.Exceptions.BaseDataException)?.StatusCode
                ?? 500;
        }
    }
}