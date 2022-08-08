using System.Collections.Generic;

namespace MyNexus.ApplicationRegistry.Application.Queries.GetAllServiceDomains
{
    /// <summary>
    ///   A query used to get a list of domain names that should be added to the CORS policy of other services.
    /// </summary>
    public class GetAllServiceDomainsQuery : QueryBase<IEnumerable<string>>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="GetAllServiceDomainsQuery"/> class.
        /// </summary>
        /// <param name="tenantId">The id of the tenant.</param>
        /// <param name="correlationId">The <see cref="CorrelationId"/> used to track the query through the system.</param>
        public GetAllServiceDomainsQuery(string tenantId, CorrelationId correlationId)
            : base(tenantId, correlationId)
        {
        }
    }
}