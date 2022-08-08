using MyNexus.ApplicationRegistry.Domain.Models;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Domain.Repositories
{
    /// <summary>
    ///   A Repository for <see cref="IMicroApplication"/> objects.
    /// </summary>
    public interface IMicroApplicationRepository
    {
        /// <summary>
        ///   Gets a <see cref="IMicroApplication"/> from the element name.
        /// </summary>
        /// <param name="tenantId">The id of the tenant.</param>
        /// <param name="elementName">The name of the element.</param>
        /// <returns>Returns a <see cref="Task{MicroApplication}"/>.</returns>
        Task<IMicroApplication> GetMicroApplicationByElementName(string tenantId, string elementName);

        /// <summary>
        ///   Gets a <see cref="IMicroApplication"/> from the fully-qualified application name (fqan) name.
        /// </summary>
        /// <param name="tenantId">The id of the tenant.</param>
        /// <param name="fqan">The fully-qualified application name.</param>
        /// <returns>Returns a <see cref="Task{MicroApplication}"/>.</returns>
        Task<IMicroApplication> GetMicroApplicationByFqan(string tenantId, string fqan);

        /// <summary>
        ///   Saves a <see cref="IMicroApplication"/> to the repository.
        /// </summary>
        /// <param name="tenantId">The id of the tenant.</param>
        /// <param name="application">The <see cref="IMicroApplication"/> to save.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task SaveMicroApplication(string tenantId, IMicroApplication application);
    }
}