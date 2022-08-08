using System;
using System.Diagnostics.CodeAnalysis;

namespace MyNexus.ApplicationRegistry.Data.Exceptions
{
    /// <summary>
    ///   The exception that is thrown if when a data layer operation fails.
    /// </summary>
    [Serializable]
    [SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "Clients should only used the exposed constructors.")]
    public class OperationFailedException : BaseDataException
    {
        [NonSerialized]
        private const string DefaultMessage = "The operation failed.";

        [NonSerialized]
        private static readonly string OperationKey = $"{typeof(OperationFailedException).FullName}.{nameof(Operation)}";

        /// <summary>
        ///   Initializes a new instance of the <see cref="OperationFailedException"/> class.
        /// </summary>
        public OperationFailedException()
            : base(DefaultMessage)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="OperationFailedException"/> class.
        /// </summary>
        /// <param name="resource">The resource that was attempted to be modified.</param>
        /// <param name="operation">The query that was executed.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public OperationFailedException(string resource, string operation, Exception innerException)
            : base(500, resource, $"The {operation} operation against {resource} failed.", innerException)
        {
            Operation = operation;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="OperationFailedException"/> class.
        /// </summary>
        /// <param name="resource">The resource that was attempted to be modified.</param>
        /// <param name="operation">The query that was executed.</param>
        /// <param name="message">A message that explains the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public OperationFailedException(string resource, string operation, string message, Exception innerException)
            : base(500, resource, message, innerException)
        {
            Operation = operation;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="OperationFailedException"/> class.
        /// </summary>
        /// <param name="resource">The resource that was attempted to be modified.</param>
        /// <param name="operation">The query that was executed.</param>
        /// <param name="message">A message that explains the exception.</param>
        public OperationFailedException(string resource, string operation, string message)
            : base(500, resource, message)
        {
            Operation = operation;
        }

        /// <summary>
        ///   Gets or sets the query that failed.
        /// </summary>
        public string Operation
        {
            get => Data.Contains(OperationKey) ? Data[OperationKey].ToString() : string.Empty;
            protected set => Data[OperationKey] = value;
        }
    }
}