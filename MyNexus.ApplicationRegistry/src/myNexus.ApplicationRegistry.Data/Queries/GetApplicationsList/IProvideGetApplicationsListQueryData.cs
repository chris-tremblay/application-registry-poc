using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Data.Queries.GetApplicationsList
{
    /// <summary>
    ///   Queries a list of registered applications from the Applications repository.
    /// </summary>
    public interface IProvideGetApplicationsListQueryData
    {
        /// <summary>
        ///   Queries a list of Application Names from the Applications repository.
        /// </summary>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<IEnumerable<string>> GetApplicationNames();
    }
}