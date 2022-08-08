using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyNexus.ApplicationRegistry.Application.Exceptions;
using System;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Web.Extensions
{
    /// <summary>
    ///   Extension method for controller.
    /// </summary>
    public static class ExecuteRequest
    {
        /// <summary>
        ///   Executes a command or query, with standard error handling.
        /// </summary>
        /// <typeparam name="TResponse">type of return object.</typeparam>
        /// <typeparam name="TController">type of the controller executing this request..</typeparam>
        /// <param name="controller">controller making the request.</param>
        /// <param name="logger">Instance of logger from MS logging.</param>
        /// <param name="action">The command or query to execute.</param>
        /// <returns>The result of the command or query.</returns>
        public static async Task<ActionResult<TResponse>> Execute<TResponse, TController>(this ControllerBase controller, ILogger<TController> logger, Func<Task<TResponse>> action)
            where TController : ControllerBase
        {
            try
            {
                return await action();
            }
            catch (InvalidCommandOrQueryException e)
            {
                logger.LogError(e, "Validation errors in command or query: {validationErrors}", string.Join(' ', e.ValidationErrors));

                return controller.StatusCode(e.StatusCode, string.Join(' ', e.ValidationErrors));
            }
            catch (BaseApplicationException e)
            {
                logger.LogError(e, e.Message.Replace("{", "[").Replace("}", "]"));

                return controller.StatusCode(e.StatusCode, e.Message);
            }
            catch (Domain.Exceptions.BaseDomainException e)
            {
                logger.LogError(e, e.Message.Replace("{", "[").Replace("}", "]"));

                return controller.StatusCode(e.StatusCode, e.Message);
            }
            catch (Data.Exceptions.BaseDataException e)
            {
                logger.LogError(e, e.Message.Replace("{", "[").Replace("}", "]"));

                return controller.StatusCode(e.StatusCode, e.Message);
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message.Replace("{", "[").Replace("}", "]"));

                return controller.StatusCode(500, e.Message);
            }
        }
    }
}