using MediatR;
using MyNexus.ApplicationRegistry.Data.Exceptions;
using MyNexus.ApplicationRegistry.Domain.Models;
using MyNexus.ApplicationRegistry.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Application.Queries.ApplicationByFqan
{
    /// <summary>
    ///   The handler for the <see cref="ApplicationByFqanQuery"/>.
    /// </summary>
    public class ApplicationByFqanQueryHandler : IRequestHandler<ApplicationByFqanQuery, IMicroApplication>
    {
        private IMicroApplicationRepository repository;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ApplicationByFqanQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">The <see cref="IMicroApplicationRepository"/> used to locate the <see cref="IMicroApplication"/>.</param>
        public ApplicationByFqanQueryHandler(IMicroApplicationRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IMicroApplication> Handle(ApplicationByFqanQuery request, CancellationToken cancellationToken)
        {
            var microApp = await repository.GetMicroApplicationByFqan(request.TenantId, request.Fqan);

            if (microApp == null)
                throw new ResourceNotFoundException(typeof(IMicroApplication), $"Fqan: {request.Fqan}");

            return microApp;
        }
    }
}