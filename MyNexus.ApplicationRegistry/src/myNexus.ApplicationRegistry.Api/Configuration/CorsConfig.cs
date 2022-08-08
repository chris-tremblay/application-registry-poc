using System.Collections.Generic;

namespace MyNexus.ApplicationRegistry.Web.Configuration
{
    /// <summary>
    ///   Contains configuration settings for the Cors Configuration.
    /// </summary>
    public class CorsConfig
    {
        /// <summary>
        ///   Gets the section name containing the configuration settings.
        /// </summary>
        public static string SectionName => "cors";

        /// <summary>
        ///   Gets or sets the list of Cors Policies.
        /// </summary>
        public IEnumerable<CorsPolicyConfig> Policies { get; set; }
    }
}