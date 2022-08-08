using MyNexus.ApplicationRegistry.Data.Queries.ElementSearch;
using MyNexus.ApplicationRegistry.Domain.Models;
using System.Collections.Generic;

namespace MyNexus.ApplicationRegistry.Application.Queries.ElementSearch
{
    /// <summary>
    ///   A query used to get a <see cref="IMicroApplication"/> by its Fully-Qualified Application Name (Fqan).
    /// </summary>
    public class ElementSearchQuery : QueryBase<IEnumerable<ElementSearchQueryResult>>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="ElementSearchQuery "/> class.
        /// </summary>
        /// <param name="tenantId">The id of the tenant.</param>
        /// <param name="correlationId">The <see cref="CorrelationId"/> used to track the query through the system.</param>
        public ElementSearchQuery(string tenantId, CorrelationId correlationId)
            : base(tenantId, correlationId)
        {
        }

        /// <summary>
        ///   Gets or sets the application name.
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        ///   Gets or sets the element name.
        /// </summary>
        public string ElementName { get; set; }

        /// <summary>
        ///   Gets or sets tags.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }
    }
}