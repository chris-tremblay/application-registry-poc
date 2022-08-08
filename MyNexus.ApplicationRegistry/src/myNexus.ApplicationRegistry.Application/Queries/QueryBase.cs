using MediatR;

namespace MyNexus.ApplicationRegistry.Application.Queries
{
    /// <summary>
    ///   A base class for queries.
    /// </summary>
    /// <typeparam name="TResponse">The type of the expected response.</typeparam>
    public class QueryBase<TResponse> : IRequest<TResponse>, IAmCorrelatable, IAmMultiTenant
    {
        protected QueryBase(string tenantId, CorrelationId correlationId)
        {
            CorrelationId = correlationId;
            TenantId = tenantId;
        }

        public CorrelationId CorrelationId { get; }

        public string TenantId { get; }
    }
}