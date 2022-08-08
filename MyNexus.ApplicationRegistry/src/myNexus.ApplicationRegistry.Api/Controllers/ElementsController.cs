using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyNexus.ApplicationRegistry.Application;
using MyNexus.ApplicationRegistry.Application.Queries.ApplicationByElementName;
using MyNexus.ApplicationRegistry.Application.Queries.ElementSearch;
using MyNexus.ApplicationRegistry.Data;
using MyNexus.ApplicationRegistry.Data.Queries.ElementSearch;
using MyNexus.ApplicationRegistry.Domain.Models;
using MyNexus.ApplicationRegistry.Web.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Web.Controller
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/{tenantId}/[Controller]")]
    public class ElementsController : ControllerBase
    {
        private readonly CorrelationId correlationId;
        private readonly ILogger<ElementsController> logger;
        private readonly IMediator mediator;
        private readonly TenantId tenantId;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ElementsController"/> class.
        /// </summary>
        /// <param name="tenantId">The <see cref="TenantId"/> of the tenant.</param>
        /// <param name="logger">The <see cref="ILogger"/> to use for logging.</param>
        /// <param name="mediator">The <see cref="IMediator"/> to use to handle command and queries.</param>
        /// <param name="correlationId">The <see cref="CorrelationId"/> for the current request.</param>
        public ElementsController(TenantId tenantId, ILogger<ElementsController> logger, IMediator mediator, CorrelationId correlationId)
        {
            this.logger = logger;
            this.mediator = mediator;
            this.correlationId = correlationId;
            this.tenantId = tenantId;
        }

        /// <summary>
        ///   Gets the script containing the <paramref name="elementName"/> definition.
        /// </summary>
        /// <param name="elementName">The name of the element to get the script definition for.</param>
        /// <returns>Returns the javascript for the specified <paramref name="elementName"/>.</returns>
        [ProducesResponseType(typeof(IMicroApplication), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("{elementName}.json")]
        public async Task<ActionResult<IMicroApplication>> GetElementMetaData(string elementName)
        {
            var query = new ApplicationByElementNameQuery(tenantId.Value, correlationId)
            {
                ElementName = elementName,
            };

            return await this.Execute(logger, async () =>
                await mediator.Send(query));
        }

        /// <summary>
        ///   Searches for applications matching the specified search options.
        /// </summary>
        /// <param name="applicationName">The name of the application.</param>
        /// <param name="elementName">The partial or full name of the element.</param>
        /// <param name="tags">A list of tags to include in the search.</param>
        /// <returns>Returns the javascript for the specified <paramref name="tags"/>.</returns>
        [ProducesResponseType(typeof(IMicroApplication), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("query")]
        public async Task<ActionResult<IEnumerable<ElementSearchQueryResult>>> Query([FromQuery] string applicationName, [FromQuery] string elementName, [FromQuery] IEnumerable<string> tags)
        {
            var query = new ElementSearchQuery(tenantId.Value, correlationId)
            {
                ApplicationName = applicationName,
                ElementName = elementName,
                Tags = tags,
            };

            return await this.Execute(logger, async () =>
                await mediator.Send(query));
        }
    }
}