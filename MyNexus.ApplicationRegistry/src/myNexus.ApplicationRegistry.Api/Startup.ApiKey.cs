using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyNexus.ApplicationRegistry.Web.Authorization;
using MyNexus.ApplicationRegistry.Web.Configuration;

namespace MyNexus.ApplicationRegistry.Web
{
    /// <summary>
    ///   The service collection extensions.
    /// </summary>
    internal static partial class ServiceCollectionExtensions
    {
        /// <summary>
        ///   Adds the <see cref="ApiKeyRequirement"/> class to the container so it can be injected.
        /// </summary>
        /// <param name="services">ServiceCollection reference.</param>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        /// <returns>IServicecollection <see cref="IServiceCollection"/>.</returns>
        internal static IServiceCollection AddApiKey(this IServiceCollection services, IConfiguration configuration)
        {
            var authorizationConfig = configuration.GetSection(AuthorizationConfiguration.SectionName).Get<AuthorizationConfiguration>();
            services.AddTransient<IAuthorizationHandler, ApiKeyRequirementHandler>();

            return services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    AuthorizationConfiguration.ApiPolicyName,
                    policyBuilder => policyBuilder
                        .AddRequirements(new ApiKeyRequirement(new[] { authorizationConfig.ApiKey })));
            });
        }
    }
}