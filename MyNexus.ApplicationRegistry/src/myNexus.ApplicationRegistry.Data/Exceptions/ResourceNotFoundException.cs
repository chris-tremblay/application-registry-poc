using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace MyNexus.ApplicationRegistry.Data.Exceptions
{
    /// <summary>
    ///   The exception that is thrown if a resource is not found.
    /// </summary>
    [Serializable]
    [SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "Clients should only used the exposed constructors.")]
    public class ResourceNotFoundException : BaseDataException
    {
        [NonSerialized]
        private const string DefaultMessage = "The specified resource was not found.";

        [NonSerialized]
        private const int DefaultStatusCode = 404;

        [NonSerialized]
        private static readonly string IdentifierKey = $"{typeof(ResourceNotFoundException).FullName}.{nameof(Identifier)}";

        /// <summary>
        ///   Initializes a new instance of the <see cref="ResourceNotFoundException"/> class.
        /// </summary>
        /// <param name="resource">The resource that was attempted to be accessed.</param>
        /// <param name="identifier">The resource unique identifier.</param>
        public ResourceNotFoundException(string resource, string identifier)
            : base(DefaultStatusCode, resource, $"{resource} with id {identifier} was not found.")
        {
            Identifier = identifier;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ResourceNotFoundException"/> class.
        /// </summary>
        /// <param name="resourceType">The <see cref="Type"/> of the resource that was attempted to be accessed.</param>
        /// <param name="identifier">The resource unique identifier.</param>
        public ResourceNotFoundException(Type resourceType, string identifier)
            : base(DefaultStatusCode, resourceType.FullName, $"{resourceType} with id {identifier} was not found.")
        {
            Identifier = identifier;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ResourceNotFoundException"/> class.
        /// </summary>
        /// <param name="resource">The resource that was attempted to be modified.</param>
        /// <param name="identifier">The resource unique identifier.</param>
        /// <param name="message">A message that explains the exception.</param>
        public ResourceNotFoundException(string resource, string identifier, string message)
            : base(DefaultStatusCode, resource, message ?? DefaultMessage)
        {
            Identifier = identifier;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ResourceNotFoundException"/> class.
        /// </summary>
        /// <param name="info">Holds the serialized object data.</param>
        /// <param name="context">Contains contextual information about the serialization.</param>
        protected ResourceNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        ///   Gets or sets the unique identifier of the resource.
        /// </summary>
        public string Identifier
        {
            get => Data.Contains(IdentifierKey) ? Data[IdentifierKey].ToString() : string.Empty;
            protected set => Data[IdentifierKey] = value;
        }
    }
}