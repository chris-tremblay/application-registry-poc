using MyNexus.ApplicationRegistry.Domain.Models;
using System.Collections.Generic;

namespace MyNexus.ApplicationRegistry.Application.Queries.GetApplicationsElementList
{
    /// <summary>
    ///   A query used to get a <see cref="IMicroApplication"/> by the element name of one of its exposed widgets.
    /// </summary>
    public class GetApplicationsElementListQuery : QueryBase<IEnumerable<string>>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="GetApplicationsElementListQuery"/> class.
        /// </summary>
        /// <param name="tenantId">The id of the tenant.</param>
        /// <param name="correlationId">The <see cref="CorrelationId"/> used to track the query through the system.</param>
        public GetApplicationsElementListQuery(string tenantId, CorrelationId correlationId)
            : base(tenantId, correlationId)
        {
        }
    }
}