using Microsoft.Extensions.Configuration;

namespace React.Members.Configuration
{
    public class RegistryConfiguration
    {
        public const string SectionName = "Registry";

        public string AuthHeader { get; set; }

        public string RegistrySecret { get; set; }

        public string RegistryUrl { get; set; }

        public static RegistryConfiguration FromConfiguration(IConfiguration configuration)
        {
            return configuration.GetSection(SectionName).Get<RegistryConfiguration>();
        }
    }
}