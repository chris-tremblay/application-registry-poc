using System;
using System.Runtime.Serialization;

namespace MyNexus.ApplicationRegistry.Application.Exceptions
{
    /// <summary>
    ///   The base exception class of the application layer.
    /// </summary>
    [Serializable]
    public abstract class BaseApplicationException : Exception
    {
        [NonSerialized]
        private const string DefaultMessage = "An unexpected exception occurred.";

        [NonSerialized]
        private const int DefaultStatusCode = 500;

        [NonSerialized]
        private static readonly string StatusCodeKey = $"{typeof(BaseApplicationException).FullName}.{nameof(StatusCode)}";

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseApplicationException"/> class.
        /// </summary>
        public BaseApplicationException()
            : this(DefaultStatusCode, DefaultMessage, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseApplicationException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        public BaseApplicationException(string message)
            : this(DefaultStatusCode, message ?? DefaultMessage, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseApplicationException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public BaseApplicationException(string message, Exception innerException)
            : this(DefaultStatusCode, message ?? DefaultMessage, innerException)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseApplicationException"/> class.
        /// </summary>
        /// <param name="statusCode">A status code used to further define the exception.</param>
        public BaseApplicationException(int statusCode)
            : base(DefaultMessage)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseApplicationException"/> class.
        /// </summary>
        /// <param name="statusCode">A status code used to further define the exception.</param>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        public BaseApplicationException(int statusCode, string message)
            : base(message ?? DefaultMessage)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseApplicationException"/> class.
        /// </summary>
        /// <param name="statusCode">A status code used to further define the exception.</param>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public BaseApplicationException(int statusCode, string message, Exception innerException)
            : base(message ?? DefaultMessage, innerException)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseApplicationException"/> class.
        /// </summary>
        /// <param name="info">Holds the serialized object data.</param>
        /// <param name="context">Contains contextual information about the serialization.</param>
        protected BaseApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        ///   Gets or sets the exception status code.
        /// </summary>
        public int StatusCode
        {
            get { return Data.Contains(StatusCodeKey) ? (int)Data[StatusCodeKey] : DefaultStatusCode; }
            protected internal set { Data[StatusCodeKey] = value; }
        }
    }
}