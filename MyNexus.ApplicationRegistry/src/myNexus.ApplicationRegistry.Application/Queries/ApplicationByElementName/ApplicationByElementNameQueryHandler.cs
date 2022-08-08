using MediatR;
using MyNexus.ApplicationRegistry.Data.Exceptions;
using MyNexus.ApplicationRegistry.Domain.Models;
using MyNexus.ApplicationRegistry.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Application.Queries.ApplicationByElementName
{
    /// <summary>
    ///   The handler for the <see cref="ApplicationByElementNameQuery"/>.
    /// </summary>
    public class ApplicationByElementNameQueryHandler : IRequestHandler<ApplicationByElementNameQuery, IMicroApplication>
    {
        private IMicroApplicationRepository repository;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ApplicationByElementNameQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">The <see cref="IMicroApplicationRepository"/> used to locate the <see cref="IMicroApplication"/>.</param>
        public ApplicationByElementNameQueryHandler(IMicroApplicationRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IMicroApplication> Handle(ApplicationByElementNameQuery request, CancellationToken cancellationToken)
        {
            var microApp = await repository.GetMicroApplicationByElementName(request.TenantId, request.ElementName);

            if (microApp == null)
                throw new ResourceNotFoundException(typeof(IMicroApplication), request.ElementName);

            return microApp;
        }
    }
}