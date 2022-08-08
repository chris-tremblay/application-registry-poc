using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Data.Queries.GetCorsAllowedOrigins
{
    /// <summary>
    ///   Provides data for the GetCorsAllowedOrigins query.
    /// </summary>
    public interface IProvideGetCorsAllowedOriginsQueryData
    {
        /// <summary>
        ///   Gets an list of script urls from the registered applications.
        /// </summary>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<IEnumerable<string>> GetScriptUrls();
    }
}