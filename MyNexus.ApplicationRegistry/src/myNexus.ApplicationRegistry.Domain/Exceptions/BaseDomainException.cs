using System;
using System.Runtime.Serialization;

namespace MyNexus.ApplicationRegistry.Domain.Exceptions
{
    /// <summary>
    ///   The base exception class of the domain layer.
    /// </summary>
    [Serializable]
    public abstract class BaseDomainException : Exception
    {
        [NonSerialized]
        private const string DefaultMessage = "An unexpected exception occurred.";

        [NonSerialized]
        private const int DefaultStatusCode = 500;

        [NonSerialized]
        private static readonly string StatusCodeKey = $"{typeof(BaseDomainException).FullName}.{nameof(StatusCode)}";

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDomainException"/> class.
        /// </summary>
        public BaseDomainException()
            : this(DefaultStatusCode, DefaultMessage, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDomainException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        public BaseDomainException(string message)
            : this(DefaultStatusCode, message ?? DefaultMessage, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDomainException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public BaseDomainException(string message, Exception innerException)
            : this(DefaultStatusCode, message ?? DefaultMessage, innerException)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDomainException"/> class.
        /// </summary>
        /// <param name="statusCode">A status code used to further define the exception.</param>
        public BaseDomainException(int statusCode)
            : base(DefaultMessage)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDomainException"/> class.
        /// </summary>
        /// <param name="statusCode">A status code used to further define the exception.</param>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        public BaseDomainException(int statusCode, string message)
            : base(message ?? DefaultMessage)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDomainException"/> class.
        /// </summary>
        /// <param name="statusCode">A status code used to further define the exception.</param>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public BaseDomainException(int statusCode, string message, Exception innerException)
            : base(message ?? DefaultMessage, innerException)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDomainException"/> class.
        /// </summary>
        /// <param name="info">Holds the serialized object data.</param>
        /// <param name="context">Contains contextual information about the serialization.</param>
        protected BaseDomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        ///   Gets or sets the exception status code.
        /// </summary>
        public int StatusCode
        {
            get => Data.Contains(StatusCodeKey) ? (int)Data[StatusCodeKey] : DefaultStatusCode;
            protected set => Data[StatusCodeKey] = value;
        }
    }
}