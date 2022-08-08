using FluentValidation;

namespace MyNexus.ApplicationRegistry.Application.Queries.GetApplicationsList
{
    /// <summary>
    ///   Validator For <see cref="GetApplicationsListQuery"/>.
    /// </summary>
    public class GetApplicationsListQueryValidator : AbstractValidator<GetApplicationsListQuery>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="GetApplicationsListQueryValidator"/> class.
        /// </summary>
        public GetApplicationsListQueryValidator()
        {
            RuleFor(request => request.TenantId).NotEmpty();
            RuleFor(request => request.CorrelationId).NotEmpty();
        }
    }
}