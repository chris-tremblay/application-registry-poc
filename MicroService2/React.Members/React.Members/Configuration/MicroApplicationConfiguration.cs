using Microsoft.Extensions.Configuration;
using React.Members.Models;

namespace React.Members.Configuration
{
    public class MicroApplicationConfiguration
    {
        public const string SectionName = "MicroApplication";

        public string AppElementName { get; set; }

        /// <summary>
        ///   Gets or sets the Fully Qualified Application Name.
        /// </summary>
        public string Fqan { get; set; }

        public string IngressBaseUrl { get; set; }

        public string[] ScriptUrls { get; set; }

        public string[] StyleUrls { get; set; }

        public Widget[] Widgets { get; set; }

        public static MicroApplicationConfiguration FromConfiguration(IConfiguration configuration)
        {
            return configuration.GetSection(SectionName).Get<MicroApplicationConfiguration>();
        }
    }
}