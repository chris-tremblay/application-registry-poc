using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyNexus.ApplicationRegistry.Application;
using MyNexus.ApplicationRegistry.Application.Commands.PutApplication;
using MyNexus.ApplicationRegistry.Application.Queries.ApplicationByFqan;
using MyNexus.ApplicationRegistry.Application.Queries.GetApplicationsElementList;
using MyNexus.ApplicationRegistry.Application.Queries.GetApplicationsList;
using MyNexus.ApplicationRegistry.Data;
using MyNexus.ApplicationRegistry.Data.Exceptions;
using MyNexus.ApplicationRegistry.Domain.Models;
using MyNexus.ApplicationRegistry.Web.Configuration;
using MyNexus.ApplicationRegistry.Web.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Web.Controllers
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/{tenantId}/[Controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly CorrelationId correlationId;
        private readonly ILogger<ApplicationsController> logger;
        private readonly IMediator mediator;
        private readonly TenantId tenantId;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ApplicationsController"/> class.
        /// </summary>
        /// <param name="tenantId">The <see cref="TenantId"/> of the tenant making the request.</param>
        /// <param name="logger">The <see cref="ILogger"/> to use for logging.</param>
        /// <param name="mediator">The <see cref="IMediator"/> to use for logging.</param>
        /// ///
        /// <param name="correlationId">The <see cref="CorrelationId"/> for the current request.</param>
        public ApplicationsController(TenantId tenantId, ILogger<ApplicationsController> logger, IMediator mediator, CorrelationId correlationId)
        {
            this.logger = logger;
            this.mediator = mediator;
            this.correlationId = correlationId;
            this.tenantId = tenantId;
        }

        /// <summary>
        ///   Gets a <see cref="IMicroApplication"/> by its fully-qualified application name.
        /// </summary>
        /// <param name="fqan">The fully-qualified name of the application.</param>
        /// <returns>Returns a <see cref="IMicroApplication"/>.</returns>
        [ProducesResponseType(typeof(IMicroApplication), 200)]
        [ProducesResponseType(typeof(ResourceNotFoundException), 404)]
        [HttpGet("{fqan}")]
        public async Task<ActionResult<IMicroApplication>> GetApplication(string fqan)
        {
            var query = new ApplicationByFqanQuery(tenantId.Value, correlationId)
            {
                Fqan = fqan,
            };

            return await this.Execute(
                logger,
                async () => await mediator.Send(query));
        }

        /// <summary>
        ///   Gets a list of application names.
        /// </summary>
        /// <returns>Returns a <see cref="IMicroApplication"/>.</returns>
        [ProducesResponseType(typeof(IMicroApplication), 200)]
        [ProducesResponseType(typeof(ResourceNotFoundException), 404)]
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<string>>> GetApplications()
        {
            var query = new GetApplicationsListQuery(tenantId.Value, correlationId);

            return await this.Execute(
                logger,
                async () => await mediator.Send(query));
        }

        /// <summary>
        ///   Gets a list of application element names.
        /// </summary>
        /// <returns>Returns a <see cref="IMicroApplication"/>.</returns>
        [ProducesResponseType(typeof(IMicroApplication), 200)]
        [ProducesResponseType(typeof(ResourceNotFoundException), 404)]
        [HttpGet("element-names")]
        public async Task<ActionResult<IEnumerable<string>>> GetApplicationsElementNames()
        {
            var query = new GetApplicationsElementListQuery(tenantId.Value, correlationId);

            return await this.Execute(
                logger,
                async () => await mediator.Send(query));
        }

        /// <summary>
        ///   Puts a <see cref="IMicroApplication"/>.
        /// </summary>
        /// <param name="fqan">The fully-qualified name of the application.</param>
        /// <param name="microApp">The micro-application to register.</param>
        /// <returns>Returns a <see cref="IMicroApplication"/>.</returns>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ResourceNotFoundException), 404)]
        [HttpPut("{fqan}")]
        [Authorize(Policy = AuthorizationConfiguration.ApiPolicyName)]
        public async Task<ActionResult<Unit>> PutApplication(string fqan, [FromBody] MicroApplication microApp)
        {
            microApp.Fqan = fqan;

            var command = new PutApplicationCommand(tenantId.Value, correlationId)
            {
                Application = microApp,
            };

            return await this.Execute(logger, async () =>
                await mediator.Send(command));
        }
    }
}