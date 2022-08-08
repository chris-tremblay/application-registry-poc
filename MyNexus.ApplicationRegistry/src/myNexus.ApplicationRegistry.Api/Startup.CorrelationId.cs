using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyNexus.ApplicationRegistry.Application;
using System;
using System.Linq;

namespace MyNexus.ApplicationRegistry.Web
{
    /// <summary>
    ///   The service collection extensions.
    /// </summary>
    internal static partial class ServiceCollectionExtensions
    {
        /// <summary>
        ///   Adds the <see cref="CorrelationId"/> class to the container so it can be injected.
        /// </summary>
        /// <param name="services">ServiceCollection reference.</param>
        /// <returns>IServicecollection <see cref="IServiceCollection"/>.</returns>
        internal static IServiceCollection AddCorrelationId(this IServiceCollection services)
        {
            return services.AddScoped(GetCorrelationId);
        }

        /// <summary>
        ///   Creates an injectable <see cref="CorrelationId"/> by grabbing the value out of the 'gsfs-correlation-id'
        ///   HTTP header.
        /// </summary>
        private static CorrelationId GetCorrelationId(IServiceProvider serviceProvider)
        {
            var httpContext = serviceProvider
                .GetRequiredService<IHttpContextAccessor>()
                .HttpContext;

            var headerValue = httpContext?.Request.Headers
                .FirstOrDefault(x => x.Key.Equals(CorrelationId.HttpHeaderName, StringComparison.InvariantCultureIgnoreCase)).Value;

            return Guid.TryParse(headerValue, out var value)
                ? new CorrelationId(value)
                : new CorrelationId(Guid.NewGuid());
        }
    }
}