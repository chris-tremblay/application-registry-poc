using FluentValidation;

namespace MyNexus.ApplicationRegistry.Application.Commands.PutApplication
{
    /// <summary>
    ///   Validator For <see cref="PutApplicationCommand"/>.
    /// </summary>
    public class PutApplicationCommandValidator : AbstractValidator<PutApplicationCommand>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="PutApplicationCommandValidator"/> class.
        /// </summary>
        public PutApplicationCommandValidator()
        {
            RuleFor(request => request.TenantId).NotEmpty();
            RuleFor(request => request.CorrelationId).NotEmpty();
            RuleFor(request => request.Application).NotNull();

            RuleFor(request => request.Application.Fqan).NotNull().NotEmpty();
            RuleFor(request => request.Application.AppElementName).NotNull().NotEmpty();
            RuleFor(request => request.Application.ScriptUrls).NotNull().NotEmpty();
        }
    }
}