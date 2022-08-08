using FluentValidation;

namespace MyNexus.ApplicationRegistry.Application.Queries.GetCorsAllowedOrigins
{
    /// <summary>
    ///   Validator For <see cref="GetCorsAllowedOriginsQuery"/>.
    /// </summary>
    public class GetCorsAllowedOriginsQueryValidator : AbstractValidator<GetCorsAllowedOriginsQuery>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="GetCorsAllowedOriginsQueryValidator"/> class.
        /// </summary>
        public GetCorsAllowedOriginsQueryValidator()
        {
            RuleFor(request => request.TenantId).NotEmpty();
            RuleFor(request => request.CorrelationId).NotEmpty();
        }
    }
}