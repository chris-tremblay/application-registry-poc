using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Data.Queries.ElementSearch
{
    /// <summary>
    ///   Queries a list of registered elements (widgets) from the repository.
    /// </summary>
    public interface IProvideElementSearchQueryData
    {
        /// <summary>
        ///   Queries a list of registered elements (widgets) from the repository.
        /// </summary>
        /// <param name="applicationName">The name of the application.</param>
        /// <param name="elementName">The full or partial name of elemments to include in the results.</param>
        /// <param name="tags">A list of tags to include in the results.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<IEnumerable<ElementSearchQueryResult>> GetElements(string applicationName, string elementName, IEnumerable<string> tags);
    }
}