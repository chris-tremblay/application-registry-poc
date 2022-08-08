using FluentValidation;

namespace MyNexus.ApplicationRegistry.Application.Queries.ElementSearch
{
    /// <summary>
    ///   Validator for <see cref="ElementSearchQuery"/>.
    /// </summary>
    public class ElementSearchQueryValidator : AbstractValidator<ElementSearchQuery>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="ElementSearchQueryValidator "/> class.
        /// </summary>
        public ElementSearchQueryValidator()
        {
            RuleFor(request => request.TenantId).NotEmpty();
            RuleFor(request => request.CorrelationId).NotEmpty();
        }
    }
}