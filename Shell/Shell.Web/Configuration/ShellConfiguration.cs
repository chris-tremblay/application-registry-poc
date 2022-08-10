using System;
using Microsoft.Extensions.Configuration;

namespace Shell.Web.Configuration
{
    /// <summary>
    ///   Configuration information for the shell.
    /// </summary>
    internal class ShellConfiguration
    {
        public ShellConfiguration(IConfiguration configuration)
        {
            var tenantSetting = $"POC.Shell:{nameof(TenantId)}";
            var registryUrlSetting = "POC.Shell:services:applicationRegistry:endpoint";

            if (string.IsNullOrEmpty(configuration[tenantSetting]))
                throw new ArgumentException($"The '{tenantSetting}' config setting was missing or invalid.", tenantSetting);

            if (string.IsNullOrEmpty(configuration[registryUrlSetting]))
                throw new ArgumentException($"The '{registryUrlSetting}' config setting was missing or invalid.", registryUrlSetting);

            DefaultRoute = configuration["Client:DefaultRoute"] ?? "/";

            TenantId = configuration[tenantSetting];
            RegistryUrl = configuration[registryUrlSetting];
        }

        public string DefaultRoute { get; set; }

        public string RegistryUrl { get; }

        public string TenantId { get; }
    }
}