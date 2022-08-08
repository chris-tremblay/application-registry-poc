using MediatR;
using MyNexus.ApplicationRegistry.Data.Queries.GetCorsAllowedOrigins;
using MyNexus.ApplicationRegistry.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Application.Queries.GetCorsAllowedOrigins
{
    /// <summary>
    ///   The handler for the <see cref="GetCorsAllowedOriginsQuery"/>.
    /// </summary>
    public class GetCorsAllowedOriginsQueryHandler : IRequestHandler<GetCorsAllowedOriginsQuery, IEnumerable<string>>
    {
        private IServiceDomainRepository devServiceRepository;
        private IProvideGetCorsAllowedOriginsQueryData provider;

        /// <summary>
        ///   Initializes a new instance of the <see cref="GetCorsAllowedOriginsQueryHandler"/> class.
        /// </summary>
        /// <param name="provider">
        ///   The <see cref="IProvideGetCorsAllowedOriginsQueryData"/> used to locate generate the domain list.
        /// </param>
        /// <param name="devServiceRepository">The <see cref="IServiceDomainRepository"/>.</param>
        public GetCorsAllowedOriginsQueryHandler(IProvideGetCorsAllowedOriginsQueryData provider, IServiceDomainRepository devServiceRepository)
        {
            this.devServiceRepository = devServiceRepository;
            this.provider = provider;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<string>> Handle(GetCorsAllowedOriginsQuery request, CancellationToken cancellationToken)
        {
            var domains = (await provider.GetScriptUrls())
                .SelectMany(i => i.Split('|'))
                .Select(j =>
                {
                    var uri = new Uri(j);

                    return $"{uri.Scheme}://{uri.Authority}";
                })
                .Distinct();

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower() == "production")
                return domains;

            return domains.Union(await devServiceRepository.GetAll());
        }
    }
}