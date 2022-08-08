using System.Collections.Generic;

namespace MyNexus.ApplicationRegistry.Web.Configuration
{
    public class CorsPolicyConfig
    {
        /// <summary>
        ///   Gets or sets a value indicating whether credentials are allowed.
        /// </summary>
        public bool AllowCredentials { get; set; }

        /// <summary>
        ///   Gets or sets the list of allowed headers.
        /// </summary>
        public IEnumerable<string> AllowHeaders { get; set; }

        /// <summary>
        ///   Gets or sets the list of allowed methods.
        /// </summary>
        public IEnumerable<string> AllowMethods { get; set; }

        /// <summary>
        ///   Gets or sets the list of allowed origins.
        /// </summary>
        public IEnumerable<string> AllowOrigins { get; set; }

        /// <summary>
        ///   Gets or sets the name of the policy.
        /// </summary>
        public string Name { get; set; }
    }
}