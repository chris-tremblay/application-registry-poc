using MediatR;
using MyNexus.ApplicationRegistry.Data.Queries.GetApplicationsList;
using MyNexus.ApplicationRegistry.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Application.Queries.GetApplicationsList
{
    /// <summary>
    ///   The handler for the <see cref="GetApplicationsListQuery"/>.
    /// </summary>
    public class GetApplicationsListQueryHandler : IRequestHandler<GetApplicationsListQuery, IEnumerable<string>>
    {
        private IProvideGetApplicationsListQueryData repository;

        /// <summary>
        ///   Initializes a new instance of the <see cref="GetApplicationsListQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">
        ///   The <see cref="IProvideGetApplicationsListQueryData"/> used to locate the <see cref="IMicroApplication"/>.
        /// </param>
        public GetApplicationsListQueryHandler(IProvideGetApplicationsListQueryData repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<string>> Handle(GetApplicationsListQuery request, CancellationToken cancellationToken)
            => await repository.GetApplicationNames();
    }
}