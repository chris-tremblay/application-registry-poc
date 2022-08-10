using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyNexus.ApplicationRegistry.Application;
using MyNexus.ApplicationRegistry.Application.Queries.GetCorsAllowedOrigins;
using MyNexus.ApplicationRegistry.Data;
using MyNexus.ApplicationRegistry.Data.Exceptions;
using MyNexus.ApplicationRegistry.Web.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Web.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/{tenantId}/[Controller]")]
    public class CorsController : ControllerBase
    {
        private readonly CorrelationId correlationId;
        private readonly ILogger<ApplicationsController> logger;
        private readonly IMediator mediator;
        private readonly TenantId tenantId;

        /// <summary>
        ///   Initializes a new instance of the <see cref="CorsController"/> class.
        /// </summary>
        /// <param name="tenantId">The <see cref="TenantId"/> of the tenant making the request.</param>
        /// <param name="logger">The <see cref="ILogger"/> to use for logging.</param>
        /// <param name="mediator">The <see cref="IMediator"/> to use for logging.</param>
        /// ///
        /// <param name="correlationId">The <see cref="CorrelationId"/> for the current request.</param>
        public CorsController(TenantId tenantId, ILogger<ApplicationsController> logger, IMediator mediator, CorrelationId correlationId)
        {
            this.logger = logger;
            this.mediator = mediator;
            this.correlationId = correlationId;
            this.tenantId = tenantId;
        }

        /// <summary>
        ///   Gets a list of allowed origins that should be included in a CORS policy to allow cross communication
        ///   between applications and widgets.
        /// </summary>
        /// <returns>Returns an <see cref="IEnumerable{T}"/>.</returns>
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [ProducesResponseType(typeof(ResourceNotFoundException), 404)]
        [HttpGet("allowed-origins")]
        public async Task<ActionResult<IEnumerable<string>>> GetCorsAllowedOriginsList()
        {
            var query = new GetCorsAllowedOriginsQuery(tenantId.Value, correlationId);

            return await this.Execute(
                logger,
                async () => await mediator.Send(query));
        }
    }
}