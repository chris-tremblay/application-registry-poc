using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MyNexus.ApplicationRegistry.Web
{
    /// <summary>
    ///   The service collection extensions.
    /// </summary>
    internal static partial class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddVersion(this IServiceCollection services)
        {
            return services.AddScoped(GetVersion);
        }

        private static Version GetVersion(IServiceProvider serviceProvider)
        {
            var httpContext = serviceProvider
                .GetRequiredService<IHttpContextAccessor>()
                .HttpContext;

            var values = httpContext.GetRouteData().Values;

            if (values.ContainsKey("version"))
                return new Version(values["version"].ToString());

            return new Version(string.Empty);
        }
    }
}