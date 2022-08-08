using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Data.Queries.GetApplicationsElementList
{
    /// <summary>
    ///   Queries a list of registered applications from the Applications repository.
    /// </summary>
    public interface IProvideGetApplicationsElementListQueryData
    {
        /// <summary>
        ///   Queries a list of Application Names from the Applications repository.
        /// </summary>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<IEnumerable<string>> GetApplicationsElementNames();
    }
}