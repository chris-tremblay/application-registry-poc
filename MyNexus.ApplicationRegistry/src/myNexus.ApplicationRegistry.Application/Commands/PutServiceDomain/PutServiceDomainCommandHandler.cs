using MediatR;
using MyNexus.ApplicationRegistry.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Application.Commands.PutServiceDomain
{
    /// <summary>
    ///   The handler for the <see cref="PutServiceDomainCommand"/>.
    /// </summary>
    public class PutServiceDomainCommandHandler : IRequestHandler<PutServiceDomainCommand>
    {
        private readonly IServiceDomainRepository repository;

        /// <summary>
        ///   Initializes a new instance of the <see cref="PutServiceDomainCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The <see cref="IServiceDomainRepository"/>..</param>
        public PutServiceDomainCommandHandler(IServiceDomainRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        ///   Handles the <see cref="PutServiceDomainCommand"/>.
        /// </summary>
        /// <param name="request">The <see cref="PutServiceDomainCommand"/> to handle.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        public async Task<Unit> Handle(PutServiceDomainCommand request, CancellationToken cancellationToken)
        {
            await repository.Add(request.ServiceDomain);
            return Unit.Value;
        }
    }
}