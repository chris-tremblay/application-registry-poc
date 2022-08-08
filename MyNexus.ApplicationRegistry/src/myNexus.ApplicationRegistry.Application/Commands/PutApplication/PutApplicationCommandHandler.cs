using MediatR;
using MyNexus.ApplicationRegistry.Domain.Models;
using MyNexus.ApplicationRegistry.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Application.Commands.PutApplication
{
    /// <summary>
    ///   The handler for the <see cref="PutApplicationCommand"/>.
    /// </summary>
    public class PutApplicationCommandHandler : IRequestHandler<PutApplicationCommand>
    {
        private readonly IMicroApplicationRepository repository;

        /// <summary>
        ///   Initializes a new instance of the <see cref="PutApplicationCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The <see cref="IMicroApplicationRepository"/> used to locate the <see cref="MicroApplication"/>.</param>
        public PutApplicationCommandHandler(IMicroApplicationRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        ///   Handles the <see cref="PutApplicationCommand"/>.
        /// </summary>
        /// <param name="request">The <see cref="PutApplicationCommand"/> to handle.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        public async Task<Unit> Handle(PutApplicationCommand request, CancellationToken cancellationToken)
        {
            await repository.SaveMicroApplication(request.TenantId, request.Application);
            return Unit.Value;
        }
    }
}