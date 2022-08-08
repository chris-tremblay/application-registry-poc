using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace MyNexus.ApplicationRegistry.Application.Commands
{
    /// <summary>
    ///   An abstract base command class that provides implementations of various required interfaces.
    /// </summary>
    /// <remarks>Inherit from this base class when the command does NOT return a response.</remarks>
    public abstract class CommandBase : CommandBase<Unit>, IRequest
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="CommandBase"/> class.
        /// </summary>
        protected CommandBase()
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CommandBase"/> class.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="correlationId">A unique correlation identifier provided by the client.</param>
        protected CommandBase(string tenantId, CorrelationId correlationId)
            : base(tenantId, correlationId)
        {
        }
    }

    /// <summary>
    ///   An abstract base command class that provides implementations of various required interfaces.
    /// </summary>
    /// <typeparam name="TResponse">The response type returned by the command.</typeparam>
    /// <remarks>Inherit from this base class when the command returns a response.</remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleType", Justification = "The two classes are related and small.")]
    public abstract class CommandBase<TResponse> : IRequest<TResponse>, IAmMultiTenant, IAmCorrelatable
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="CommandBase{TResponse}"/> class.
        /// </summary>
        protected CommandBase()
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CommandBase{TResponse}"/> class.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="correlationId">A unique correlation identifier provided by the client.</param>
        protected CommandBase(string tenantId, CorrelationId correlationId)
        {
            TenantId = tenantId;
            CorrelationId = correlationId;
        }

        /// <summary>
        ///   Gets or sets the correlation identifier for the request.
        /// </summary>
        public CorrelationId CorrelationId { get; protected set; }

        /// <summary>
        ///   Gets or sets the tenant identifier for the request.
        /// </summary>
        public string TenantId { get; protected set; }
    }
}