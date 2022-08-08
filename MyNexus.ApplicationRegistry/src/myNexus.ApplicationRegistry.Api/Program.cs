using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MyNexus.ApplicationRegistry.Application.Extensions;
using Serilog;
using Serilog.Events;
using System;

namespace MyNexus.ApplicationRegistry.Web
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog((context, loggerConfiguration) =>
                {
                    loggerConfiguration
                    .Enrich.WithDemystifiedStackTraces()
                    .ReadFrom.Configuration(context.Configuration);
                });
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("[HTTP] The {0} host is starting...", typeof(Program).Namespace);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args)
                    .Build()
                    .MigrateDatabase()
                    .Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}