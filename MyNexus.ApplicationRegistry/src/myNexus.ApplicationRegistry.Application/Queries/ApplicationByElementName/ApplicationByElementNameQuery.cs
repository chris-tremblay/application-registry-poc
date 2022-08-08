using MyNexus.ApplicationRegistry.Domain.Models;

namespace MyNexus.ApplicationRegistry.Application.Queries.ApplicationByElementName
{
    /// <summary>
    ///   A query used to get a <see cref="IMicroApplication"/> by the element name of one of its exposed widgets.
    /// </summary>
    public class ApplicationByElementNameQuery : QueryBase<IMicroApplication>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="ApplicationByElementNameQuery"/> class.
        /// </summary>
        /// <param name="tenantId">The id of the tenant.</param>
        /// <param name="correlationId">The <see cref="CorrelationId"/> used to track the query through the system.</param>
        public ApplicationByElementNameQuery(string tenantId, CorrelationId correlationId)
            : base(tenantId, correlationId)
        {
        }

        /// <summary>
        ///   Gets or sets the element name.
        /// </summary>
        public string ElementName { get; set; }
    }
}