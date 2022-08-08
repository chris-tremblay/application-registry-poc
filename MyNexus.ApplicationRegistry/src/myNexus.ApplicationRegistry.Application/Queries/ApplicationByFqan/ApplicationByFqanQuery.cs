using MyNexus.ApplicationRegistry.Domain.Models;

namespace MyNexus.ApplicationRegistry.Application.Queries.ApplicationByFqan
{
    /// <summary>
    ///   A query used to get a <see cref="IMicroApplication"/> by its Fully-Qualified Application Name (Fqan).
    /// </summary>
    public class ApplicationByFqanQuery : QueryBase<IMicroApplication>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="ApplicationByFqanQuery "/> class.
        /// </summary>
        /// <param name="tenantId">The id of the tenant.</param>
        /// <param name="correlationId">The <see cref="CorrelationId"/> used to track the query through the system.</param>
        public ApplicationByFqanQuery(string tenantId, CorrelationId correlationId)
            : base(tenantId, correlationId)
        {
        }

        /// <summary>
        ///   Gets or sets the fully-qualified application name.
        /// </summary>
        public string Fqan { get; set; }
    }
}