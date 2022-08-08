using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyNexus.ApplicationRegistry.Data;

namespace MyNexus.ApplicationRegistry.Application.Extensions
{
    public static class HostExtensions
    {
        /// <summary>
        ///   Migrates the database.
        /// </summary>
        /// <param name="host">The <see cref="IHost"/> that is being extended.</param>
        /// <returns>The <see cref="IHost"/>.</returns>
        internal static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<Migrator>().RunMigrations();
            }

            return host;
        }
    }
}