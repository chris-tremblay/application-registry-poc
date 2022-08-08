using System.Collections.Generic;

namespace MyNexus.ApplicationRegistry.Application.Queries.GetCorsAllowedOrigins
{
    /// <summary>
    ///   A query used to get a list of domain names that should be added to the CORS policy of other services.
    /// </summary>
    public class GetCorsAllowedOriginsQuery : QueryBase<IEnumerable<string>>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="GetCorsAllowedOriginsQuery"/> class.
        /// </summary>
        /// <param name="tenantId">The id of the tenant.</param>
        /// <param name="correlationId">The <see cref="CorrelationId"/> used to track the query through the system.</param>
        public GetCorsAllowedOriginsQuery(string tenantId, CorrelationId correlationId)
            : base(tenantId, correlationId)
        {
        }
    }
}