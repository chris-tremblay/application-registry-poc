using MediatR;
using MyNexus.ApplicationRegistry.Data.Queries.GetApplicationsElementList;
using MyNexus.ApplicationRegistry.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Application.Queries.GetApplicationsElementList
{
    /// <summary>
    ///   The handler for the <see cref="GetApplicationsElementListQuery"/>.
    /// </summary>
    public class GetApplicationsElementListQueryHandler : IRequestHandler<GetApplicationsElementListQuery, IEnumerable<string>>
    {
        private IProvideGetApplicationsElementListQueryData repository;

        /// <summary>
        ///   Initializes a new instance of the <see cref="GetApplicationsElementListQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">
        ///   The <see cref="IProvideGetApplicationsElementListQueryData"/> used to locate the <see cref="IMicroApplication"/>.
        /// </param>
        public GetApplicationsElementListQueryHandler(IProvideGetApplicationsElementListQueryData repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<string>> Handle(GetApplicationsElementListQuery request, CancellationToken cancellationToken)
            => await repository.GetApplicationsElementNames();
    }
}