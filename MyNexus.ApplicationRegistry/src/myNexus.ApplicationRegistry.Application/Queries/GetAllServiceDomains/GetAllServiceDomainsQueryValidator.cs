using FluentValidation;

namespace MyNexus.ApplicationRegistry.Application.Queries.GetAllServiceDomains
{
    /// <summary>
    ///   Validator For <see cref="GetAllServiceDomainsQuery"/>.
    /// </summary>
    public class GetAllServiceDomainsQueryValidator : AbstractValidator<GetAllServiceDomainsQuery>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="GetAllServiceDomainsQueryValidator"/> class.
        /// </summary>
        public GetAllServiceDomainsQueryValidator()
        {
            RuleFor(request => request.TenantId).NotEmpty();
            RuleFor(request => request.CorrelationId).NotEmpty();
        }
    }
}