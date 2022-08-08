using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyNexus.ApplicationRegistry.Application;
using MyNexus.ApplicationRegistry.Application.Commands.PutServiceDomain;
using MyNexus.ApplicationRegistry.Application.Queries.GetAllServiceDomains;
using MyNexus.ApplicationRegistry.Data;
using MyNexus.ApplicationRegistry.Data.Exceptions;
using MyNexus.ApplicationRegistry.Web.Configuration;
using MyNexus.ApplicationRegistry.Web.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Web.Controllers
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/{tenantId}/service-domains")]
    public class ServiceDomainsController : ControllerBase
    {
        private readonly CorrelationId correlationId;
        private readonly ILogger<ApplicationsController> logger;
        private readonly IMediator mediator;
        private readonly TenantId tenantId;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceDomainsController"/> class.
        /// </summary>
        /// <param name="tenantId">The <see cref="TenantId"/> of the tenant making the request.</param>
        /// <param name="logger">The <see cref="ILogger"/> to use for logging.</param>
        /// <param name="mediator">The <see cref="IMediator"/> to use for logging.</param>
        /// ///
        /// <param name="correlationId">The <see cref="CorrelationId"/> for the current request.</param>
        public ServiceDomainsController(TenantId tenantId, ILogger<ApplicationsController> logger, IMediator mediator, CorrelationId correlationId)
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
        /// <param name="serviceDomain">The serviceDomain to add to the repository.</param>
        /// <returns>Returns an <see cref="IEnumerable{T}"/>.</returns>
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [ProducesResponseType(typeof(ResourceNotFoundException), 404)]
        [HttpPut("")]
        [Authorize(Policy = AuthorizationConfiguration.ApiPolicyName)]
        public async Task<ActionResult<Unit>> Add([FromQuery] string serviceDomain)
        {
            var query = new PutServiceDomainCommand(tenantId.Value, correlationId)
            {
                ServiceDomain = serviceDomain,
            };

            return await this.Execute(
                logger,
                async () => await mediator.Send(query));
        }

        /// <summary>
        ///   Gets a list of all service domains.
        /// </summary>
        /// <returns>Returns an <see cref="IEnumerable{T}"/>.</returns>
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [ProducesResponseType(typeof(ResourceNotFoundException), 404)]
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllServiceDomains()
        {
            var query = new GetAllServiceDomainsQuery(tenantId.Value, correlationId);

            return await this.Execute(
                logger,
                async () => await mediator.Send(query));
        }
    }
}