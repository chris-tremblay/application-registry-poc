using MediatR;
using MyNexus.ApplicationRegistry.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Application.Queries.GetAllServiceDomains
{
    /// <summary>
    ///   The handler for the <see cref="GetAllServiceDomainsQuery"/>.
    /// </summary>
    public class GetAllServiceDomainsQueryHandler : IRequestHandler<GetAllServiceDomainsQuery, IEnumerable<string>>
    {
        private IServiceDomainRepository devServiceRepository;

        /// <summary>
        ///   Initializes a new instance of the <see cref="GetAllServiceDomainsQueryHandler"/> class.
        /// </summary>
        /// <param name="devServiceRepository">The <see cref="IServiceDomainRepository"/>.</param>
        public GetAllServiceDomainsQueryHandler(IServiceDomainRepository devServiceRepository)
        {
            this.devServiceRepository = devServiceRepository;
        }

        /// <inheritdoc/>
        public Task<IEnumerable<string>> Handle(GetAllServiceDomainsQuery request, CancellationToken cancellationToken)
            => devServiceRepository.GetAll();
    }
}