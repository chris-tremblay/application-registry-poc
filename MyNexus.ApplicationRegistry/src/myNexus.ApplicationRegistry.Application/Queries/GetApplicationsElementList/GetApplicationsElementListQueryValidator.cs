using FluentValidation;

namespace MyNexus.ApplicationRegistry.Application.Queries.GetApplicationsElementList
{
    /// <summary>
    ///   Validator For <see cref="GetApplicationsElementListQuery"/>.
    /// </summary>
    public class GetApplicationsElementListQueryValidator : AbstractValidator<GetApplicationsElementListQuery>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="GetApplicationsElementListQueryValidator"/> class.
        /// </summary>
        public GetApplicationsElementListQueryValidator()
        {
            RuleFor(request => request.TenantId).NotEmpty();
            RuleFor(request => request.CorrelationId).NotEmpty();
        }
    }
}