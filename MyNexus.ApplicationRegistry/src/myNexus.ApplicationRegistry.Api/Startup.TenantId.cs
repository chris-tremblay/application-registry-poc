using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using MyNexus.ApplicationRegistry.Data;
using System;

namespace MyNexus.ApplicationRegistry.Web
{
    /// <summary>
    ///   The service collection extensions.
    /// </summary>
    internal static partial class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddTenantId(this IServiceCollection services)
        {
            return services.AddScoped(GetTenantId);
        }

        private static TenantId GetTenantId(IServiceProvider serviceProvider)
        {
            var httpContext = serviceProvider
                .GetRequiredService<IHttpContextAccessor>()
                .HttpContext;

            var values = httpContext.GetRouteData().Values;

            if (values.ContainsKey("tenantId"))
            {
                return new TenantId(values["tenantId"].ToString());
            }

            return new TenantId(string.Empty);
        }
    }
}