using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyNexus.ApplicationRegistry.Application.Behaviors;

namespace MyNexus.ApplicationRegistry.Application
{
    /// <summary>
    ///   Extension methods for <see cref="IServiceCollection"/> used to register dependencies with the IoC container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///   Registers all the application layer dependencies with the IoC container.
        /// </summary>
        /// <param name="services">The container service collection.</param>
        /// <param name="configuration">The application configuration.</param>
        /// <returns>The populated <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            /* NOTE: The MetricsBehavior MUST be registered before the ValidateBehavior. Otherwise,
             * validation errors will not be captured in the metric. The logging behavior should
             * likewise be registered before the metrics behavior, so that any errors arising from
             * collecting metrics or validation get logged. As a general rule, always put the logging
             * behavior first in the list of pipeline components.
             * */
            services
                .AddMediatR(typeof(AssemblyMarker))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
                /*.AddTransient(typeof(IPipelineBehavior<,>), typeof(MetricsBehavior<,>))*/
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidateBehavior<,>))
                ;

            /* NOTE:
             * The AssemblyScanner we use below will find the validators. However, it only finds them if the
             * validator classes are public. That sucks because ideally we sould make the validators internal
             * classes. We "could" write our own assembly scanner, but for now just use what we have.
             */

            FluentValidation.AssemblyScanner
                .FindValidatorsInAssemblyContaining<AssemblyMarker>()
                .ForEach(result => services.AddTransient(result.InterfaceType, result.ValidatorType));

            /* We use AutoMapper to map objects from one form to another.
             */
            /*
           services.AddAutoMapper(typeof(AssemblyMarker));
           */

            /* ServiceBus
             */
            /*
           services.AddSingleton(serviceProvider => EndpointInstanceFactory.Build(serviceProvider, services));
           */
            /* HttpClient message handlers that flow information during server-to-server calls.
             * */

            return services;
        }
    }
}