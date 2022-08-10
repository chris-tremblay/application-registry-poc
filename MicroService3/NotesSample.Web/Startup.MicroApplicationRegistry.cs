using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotesSample.Web.Configuration;

namespace NotesSample.Web
{
    /// <summary>
    ///   Extensions for an <see cref="IApplicationBuilder"/> object.
    /// </summary>
    public static partial class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder RegisterMicroApplication(this IApplicationBuilder app, IConfiguration configuration)
        {
            var client = app.ApplicationServices.GetRequiredService<IMicroApplicationRegistryClient>();

            client.RegisterMicroApplication();

            return app;
        }
    }

    /// <summary>
    ///   Extensions for an <see cref="IServiceCollection"/> object.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        ///   Adds the <see cref="IMicroApplicationRegistryClient"/> to the service list.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="config">The <see cref="IConfiguration"/> containing application settings.</param>
        /// <returns>Returns the <paramref name="services"/> object.</returns>
        public static IServiceCollection AddMicroApplicationRegistryClient(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<IMicroApplicationRegistryClient, MicroApplicationRegistryClient>((provider, client) =>
            {
                var registryConfig = config.GetSection(RegistryConfiguration.SectionName).Get<RegistryConfiguration>();

                client.DefaultRequestHeaders.Add(registryConfig.AuthHeader, registryConfig.RegistrySecret);
                client.BaseAddress = new Uri(registryConfig.RegistryUrl);
            });

            return services;
        }
    }
}