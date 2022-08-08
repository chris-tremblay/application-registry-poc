namespace MyNexus.ApplicationRegistry.Data
{
    /// <summary>
    ///   An injectable tenant id, pulled from the route.
    /// </summary>
    public class TenantId
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="TenantId"/> class.
        /// </summary>
        /// <param name="value">The tenant id value.</param>
        public TenantId(string value)
        {
            Value = value;
        }

        /// <summary>
        ///   Gets the value of the tenant id.
        /// </summary>
        public string Value { get; }
    }
}