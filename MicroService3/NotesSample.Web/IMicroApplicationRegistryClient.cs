using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotesSample.Web
{
    /// <summary>
    ///   A client used for configuring a micro service.
    /// </summary>
    public interface IMicroApplicationRegistryClient
    {
        /// <summary>
        ///   Gets the BaseUrl for the client.
        /// </summary>
        string BaseUrl { get; }

        /// <summary>
        ///   Sends a GET request to the application registry server for the relative URL.
        /// </summary>
        /// <param name="relativeUrl">The relative URL to GET.</param>
        /// <returns>Returns the <see cref="HttpResponseMessage"/>.</returns>
        Task<HttpResponseMessage> Get(string relativeUrl);

        /// <summary>
        ///   Gets a list of allowed origins for cross service communication.
        /// </summary>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<IEnumerable<string>> GetCorsAllowedOrigins();

        /// <summary>
        ///   Gets an element definition by its name.
        /// </summary>
        /// <param name="elementName">The name of the elemnt to load.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<string> GetElementDefinition(string elementName);

        /// <summary>
        ///   Registers the micro applicaton with the Micro Application Registry.
        /// </summary>
        void RegisterMicroApplication();

        /// <summary>
        ///   Registers the proxy <paramref name="serviceDomain"/>.
        /// </summary>
        /// <param name="serviceDomain">The domain (an optionally port) of the proxy.</param>
        void RegisterMicroApplicationProxy(string serviceDomain);
    }
}