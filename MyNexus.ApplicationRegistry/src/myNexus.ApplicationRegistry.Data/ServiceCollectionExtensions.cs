using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyNexus.ApplicationRegistry.Data.Extensions;
using MyNexus.ApplicationRegistry.Data.Queries.ElementSearch;
using MyNexus.ApplicationRegistry.Data.Queries.GetApplicationsElementList;
using MyNexus.ApplicationRegistry.Data.Queries.GetApplicationsList;
using MyNexus.ApplicationRegistry.Data.Queries.GetCorsAllowedOrigins;
using MyNexus.ApplicationRegistry.Data.Repositories;
using MyNexus.ApplicationRegistry.Domain.Repositories;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MyNexus.ApplicationRegistry.Data
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///   Adds the data layer services to the IoC container.
        /// </summary>
        /// <param name="services">The <seealso cref="IServiceCollection"/> object that is being extended.</param>
        /// <param name="configuration">
        ///   An <seealso cref="IConfiguration"/> object containing the application configuration settings.
        /// </param>
        /// <returns>Return the <seealso cref="IServiceCollection"/> object that is being extended.</returns>
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddFluentMigratorCore()
                .ConfigureRunner(runner => runner
                    .AddSqlServer()
                    .WithGlobalConnectionString(configuration.GetConnectionString())
                    .ScanIn(typeof(AssemblyMarker).Assembly)
                        .For.EmbeddedResources()
                        .For.Migrations())
                .AddTransient<Migrator>()
                .AddScoped<IDbConnection>(OpenConnection)

                // Queries
                .AddScoped<IProvideElementSearchQueryData, SqlElementSearchQueryDataProvider>()
                .AddScoped<IProvideGetApplicationsListQueryData, SqlGetApplicationsListQueryDataProvider>()
                .AddScoped<IProvideGetCorsAllowedOriginsQueryData, SqlCorsAllowedOriginsDataProvider>()
                .AddScoped<IProvideGetApplicationsElementListQueryData, SqlGetApplicationsElementListQueryDataProvider>()

                // Repositories
                .AddScoped<IMicroApplicationRepository, SqlMicroApplicationRepository>()
                .AddScoped<IServiceDomainRepository, SqlServiceDomainRepository>()
                .AddScoped<SqlMicroApplicationRepository>()
                .AddScoped<SqlServiceDomainRepository>();
        }

        private static SqlConnection OpenConnection(IServiceProvider provider)
        {
            var connectionString = provider
                .GetRequiredService<IConfiguration>()
                .GetConnectionString();

            var cnn = new SqlConnection(connectionString);
            cnn.Open();

            return cnn;
        }
    }
}