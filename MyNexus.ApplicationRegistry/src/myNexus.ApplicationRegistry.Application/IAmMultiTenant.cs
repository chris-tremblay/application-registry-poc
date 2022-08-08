namespace MyNexus.ApplicationRegistry.Application
{
    /// <summary>
    ///   Indicates that a request supports tenants.
    /// </summary>
    public interface IAmMultiTenant
    {
        /// <summary>
        ///   Gets the tenantId.
        /// </summary>
        string TenantId { get; }
    }
}