using MediatR;
using MyNexus.ApplicationRegistry.Data.Queries.ElementSearch;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Application.Queries.ElementSearch
{
    /// <summary>
    ///   The handler for the <see cref="ElementSearchQuery"/>.
    /// </summary>
    public class ElementSearchQueryHandler : IRequestHandler<ElementSearchQuery, IEnumerable<ElementSearchQueryResult>>
    {
        private IProvideElementSearchQueryData provider;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ElementSearchQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">The <see cref="IProvideElementSearchQueryData"/> used to locate the <see cref="ElementSearchQueryResult"/>.</param>
        public ElementSearchQueryHandler(IProvideElementSearchQueryData repository)
        {
            this.provider = repository;
        }

        /// <summary>
        ///   Handles a <see cref="ElementSearchQuery"/>.
        /// </summary>
        /// <param name="request">The <see cref="ElementSearchQuery"/> to handle.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used to cancel a pending request.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        public async Task<IEnumerable<ElementSearchQueryResult>> Handle(ElementSearchQuery request, CancellationToken cancellationToken)
        {
            return await provider.GetElements(request.ApplicationName, request.ElementName, request.Tags);
        }
    }
}