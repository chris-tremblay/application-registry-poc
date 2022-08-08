using FluentValidation;

namespace MyNexus.ApplicationRegistry.Application.Commands.PutServiceDomain
{
    /// <summary>
    ///   Validator For <see cref="PutServiceDomainCommand"/>.
    /// </summary>
    public class PutServiceDomainCommandValidator : AbstractValidator<PutServiceDomainCommand>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="PutServiceDomainCommandValidator"/> class.
        /// </summary>
        public PutServiceDomainCommandValidator()
        {
            RuleFor(request => request.TenantId).NotEmpty();
            RuleFor(request => request.CorrelationId).NotEmpty();
            RuleFor(request => request.ServiceDomain).NotNull();
        }
    }
}