using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Domain.Repositories
{
    /// <summary>
    ///   A repository for managing dev services.
    /// </summary>
    public interface IServiceDomainRepository
    {
        /// <summary>
        ///   Adds a new DevService to the repository.
        /// </summary>
        /// <param name="serviceDomain">The domain for the service.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        public Task Add(string serviceDomain);

        /// <summary>
        ///   Gets a list of dev services.
        /// </summary>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        public Task<IEnumerable<string>> GetAll();
    }
}