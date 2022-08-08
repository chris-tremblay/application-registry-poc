using MediatR;

namespace MyNexus.ApplicationRegistry.Application.Commands.PutServiceDomain
{
    /// <summary>
    ///   Saves a new service domain for a dev service.
    /// </summary>
    public class PutServiceDomainCommand : CommandBase, IRequest
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="PutServiceDomainCommand"/> class.
        /// </summary>
        /// <param name="tenantId">The id of the tenant.</param>
        /// <param name="correlationId">The <see cref="CorrelationId"/> of the request.</param>
        public PutServiceDomainCommand(string tenantId, CorrelationId correlationId)
            : base(tenantId, correlationId)
        {
        }

        /// <summary>
        ///   Gets or sets the Service Domain to save.
        /// </summary>
        public string ServiceDomain { get; set; }
    }
}