using App.Metrics;
using Microsoft.Extensions.DependencyInjection;
using MyNexus.ApplicationRegistry.Application;

namespace MyNexus.ApplicationRegistry.Web
{
    /// <summary>
    ///   The service collection extensions.
    /// </summary>
    internal static partial class ServiceCollectionExtensions
    {
        /// <summary>
        ///   Adds the <see cref="CorrelationId"/> class to the container so it can be injected.
        /// </summary>
        /// <param name="services">ServiceCollection reference.</param>
        /// <returns>IServicecollection <see cref="IServiceCollection"/>.</returns>
        internal static IServiceCollection AddMetrics(this IServiceCollection services)
        {
            var metrics = new MetricsBuilder()
                    .Report.ToConsole()
                    .Build();

            services.AddSingleton<IMetrics>(metrics);

            return services;
        }
    }
}