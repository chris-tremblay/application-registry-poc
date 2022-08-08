using FluentValidation;

namespace MyNexus.ApplicationRegistry.Application.Queries.ApplicationByFqan
{
    /// <summary>
    ///   Validator for <see cref="ApplicationByFqanQuery"/>.
    /// </summary>
    public class ApplicationByFqanQueryValidator : AbstractValidator<ApplicationByFqanQuery>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="ApplicationByFqanQueryValidator "/> class.
        /// </summary>
        public ApplicationByFqanQueryValidator()
        {
            RuleFor(request => request.TenantId).NotEmpty();
            RuleFor(request => request.CorrelationId).NotEmpty();
            RuleFor(request => request.Fqan).NotNull().NotEmpty();
        }
    }
}