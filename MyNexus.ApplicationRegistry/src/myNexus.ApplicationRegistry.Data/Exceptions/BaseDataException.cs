using System;
using System.Runtime.Serialization;

namespace MyNexus.ApplicationRegistry.Data.Exceptions
{
    /// <summary>
    ///   The base exception class of the data layer.
    /// </summary>
    [Serializable]
    public class BaseDataException : Exception
    {
        [NonSerialized]
        private const string DefaultMessage = "An unexpected exception occurred.";

        [NonSerialized]
        private const int DefaultStatusCode = 500;

        [NonSerialized]
        private static readonly string ResourceKey = $"{typeof(BaseDataException).FullName}.{nameof(Resource)}";

        [NonSerialized]
        private static readonly string StatusCodeKey = $"{typeof(BaseDataException).FullName}.StatusCode";

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDataException"/> class.
        /// </summary>
        public BaseDataException()
            : this(DefaultStatusCode, DefaultMessage)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDataException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        public BaseDataException(string message)
            : this(DefaultStatusCode, message ?? DefaultMessage)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDataException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public BaseDataException(string message, Exception innerException)
            : this(DefaultStatusCode, message ?? DefaultMessage, innerException)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDataException"/> class.
        /// </summary>
        /// <param name="statusCode">A status code used to further define the exception.</param>
        public BaseDataException(int statusCode)
            : base(DefaultMessage)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDataException"/> class.
        /// </summary>
        /// <param name="statusCode">A status code used to further define the exception.</param>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        public BaseDataException(int statusCode, string message)
            : base(message ?? DefaultMessage)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDataException"/> class.
        /// </summary>
        /// <param name="statusCode">A status code used to further define the exception.</param>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public BaseDataException(int statusCode, string message, Exception innerException)
            : base(message ?? DefaultMessage, innerException)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDataException"/> class.
        /// </summary>
        /// <param name="statusCode">A status code used to further define the exception.</param>
        /// <param name="resource">The resource that was attempted to be modified.</param>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        public BaseDataException(int statusCode, string resource, string message)
            : base(message ?? DefaultMessage, null)
        {
            StatusCode = statusCode;
            Resource = resource;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDataException"/> class.
        /// </summary>
        /// <param name="statusCode">A status code used to further define the exception.</param>
        /// <param name="resource">The resource that was attempted to be modified.</param>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public BaseDataException(int statusCode, string resource, string message, Exception innerException)
            : base(message ?? DefaultMessage, innerException)
        {
            StatusCode = statusCode;
            Resource = resource;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseDataException"/> class.
        /// </summary>
        /// <param name="info">Holds the serialized object data.</param>
        /// <param name="context">Contains contextual information about the serialization.</param>
        protected BaseDataException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        ///   Gets or sets the resource that was attempted to be modified.
        /// </summary>
        public string Resource
        {
            get => Data.Contains(ResourceKey) ? Data[ResourceKey].ToString() : string.Empty;
            protected set => Data[ResourceKey] = value;
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