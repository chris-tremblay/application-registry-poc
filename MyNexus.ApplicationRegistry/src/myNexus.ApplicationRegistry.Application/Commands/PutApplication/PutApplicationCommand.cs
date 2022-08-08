using MediatR;
using MyNexus.ApplicationRegistry.Domain.Models;

namespace MyNexus.ApplicationRegistry.Application.Commands.PutApplication
{
    public class PutApplicationCommand : CommandBase, IRequest
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="PutApplicationCommand"/> class.
        /// </summary>
        /// <param name="tenantId">The id of the tenant.</param>
        /// <param name="correlationId">The <see cref="CorrelationId"/> of the request.</param>
        public PutApplicationCommand(string tenantId, CorrelationId correlationId)
            : base(tenantId, correlationId)
        {
        }

        /// <summary>
        ///   Gets or sets the <see cref="IMicroApplication"/> to save.
        /// </summary>
        public IMicroApplication Application { get; set; }
    }
}