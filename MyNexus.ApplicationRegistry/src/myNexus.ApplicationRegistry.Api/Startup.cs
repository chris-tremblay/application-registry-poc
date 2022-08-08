using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MyNexus.ApplicationRegistry.Application;
using MyNexus.ApplicationRegistry.Data;

namespace MyNexus.ApplicationRegistry.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(Configuration);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();
            services.AddApiVersioning();
            services.AddControllers();
            services.AddHealthChecks();
            services.AddCors(Configuration);

            // Add our services.
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services
                .AddApiKey(Configuration)
                .AddApplicationServices(Configuration)
                .AddDataServices(Configuration)
                .AddCorrelationId()
                .AddTenantId()
                .AddVersion()
                .AddMetrics();
        }
    }
}