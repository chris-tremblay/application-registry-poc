namespace Shell.Web.Configuration
{
    public class ApplicationRegistryServiceConfiguration
    {
        public const string SectionName = "CustomerPortal.Shell:services:applicationRegistry";

        public string ApiKey { get; set; }

        public string Endpoint { get; set; }
    }
}