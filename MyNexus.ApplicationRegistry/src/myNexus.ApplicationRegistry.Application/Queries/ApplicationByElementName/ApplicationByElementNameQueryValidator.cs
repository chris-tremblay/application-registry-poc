using FluentValidation;

namespace MyNexus.ApplicationRegistry.Application.Queries.ApplicationByElementName
{
    /// <summary>
    ///   Validator For <see cref="ApplicationByElementNameQuery"/>.
    /// </summary>
    public class ApplicationByElementNameQueryValidator : AbstractValidator<ApplicationByElementNameQuery>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="ApplicationByElementNameQueryValidator"/> class.
        /// </summary>
        public ApplicationByElementNameQueryValidator()
        {
            RuleFor(request => request.TenantId).NotEmpty();
            RuleFor(request => request.CorrelationId).NotEmpty();
            RuleFor(request => request.ElementName).NotNull().NotEmpty();
        }
    }
}