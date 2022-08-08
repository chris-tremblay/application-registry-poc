using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyNexus.ApplicationRegistry.Web.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MyNexus.ApplicationRegistry.Web
{
    /// <summary>
    ///   Contains extensions for an <see cref="IApplicationBuilder"/> object.
    /// </summary>
    internal static partial class ApplicationBuilderExtensions
    {
        /// <summary>
        ///   Adds Cors policies to the pipeline.
        /// </summary>
        /// <param name="builder">The <see cref="IApplicationBuilder"/> object that will be operated on.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> containing the Cors configuration.</param>
        /// <returns>Returns the <see cref="IApplicationBuilder"/> instance.</returns>
        internal static IApplicationBuilder UseCors(this IApplicationBuilder builder, IConfiguration configuration)
        {
            var config = configuration.GetSection(CorsConfig.SectionName).Get<CorsConfig>();

            foreach (var policy in config.Policies)
                builder.UseCors(policy.Name);

            return builder;
        }
    }

    /// <summary>
    ///   Contains extensions for an <see cref="IServiceCollection"/> object.
    /// </summary>
    [SuppressMessage("Maintainability Rules", "SA1402", Justification = "Startup configuration should be grouped.")]
    internal static partial class ServiceCollectionExtensions
    {
        /// <summary>
        ///   Adds the Cors policies to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which to add the Cors configuration.</param>
        /// <param name="configuration">
        ///   The <see cref="IConfiguration"/> containing the <see cref="CorsConfig"/> settings.
        /// </param>
        /// <returns>Returns the <see cref="IServiceCollection"/> to which the Cors services were added.</returns>
        internal static IServiceCollection AddCors(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection(CorsConfig.SectionName).Get<CorsConfig>();

            services.AddCors(o =>
            {
                foreach (var policy in config.Policies)
                    o.AddPolicy(policy.Name, builder => policy.Build(builder));
            });

            return services;
        }

        /// <summary>
        ///   Builds a Cors colicy from a <see cref="CorsPolicyConfig"/> object.
        /// </summary>
        /// <param name="config">The <see cref="CorsPolicyConfig"/> object from which to build the Cors Policy.</param>
        /// <param name="builder">The <see cref="CorsPolicyBuilder"/> object used to build the Cors policy.</param>
        /// <returns>Returns the <see cref="CorsPolicyBuilder"/>.</returns>
        private static CorsPolicyBuilder Build(this CorsPolicyConfig config, CorsPolicyBuilder builder)
        {
            if (config.AllowCredentials)
                builder.AllowCredentials();

            if (config.AllowHeaders?.Any(i => i == "*") == true)
                builder.AllowAnyHeader();
            else
                builder.WithHeaders(config.AllowHeaders.ToArray());

            if (config.AllowMethods?.Any(i => i == "*") == true)
                builder.AllowAnyMethod();
            else
                builder.WithMethods(config.AllowMethods.ToArray());

            if (config.AllowOrigins?.Any(i => i == "*") == true)
                builder.AllowAnyOrigin();
            else
                builder.WithOrigins(config.AllowOrigins.ToArray());

            if (config.AllowOrigins.Any(i => i.Contains("*")))
                builder.SetIsOriginAllowedToAllowWildcardSubdomains();

            return builder;
        }
    }
}