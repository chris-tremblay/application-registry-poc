namespace MyNexus.ApplicationRegistry.Web.Configuration
{
    /// <summary>
    ///   Contains the authorization configuration.
    /// </summary>
    public class AuthorizationConfiguration
    {
        public const string ApiPolicyName = "mnc-registry-api-key";

        public const string SectionName = "Services.ApplicationRegistry:Authorization";

        public string ApiKey { get; set; }
    }
}