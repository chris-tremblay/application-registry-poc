using App.Metrics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyNexus.ApplicationRegistry.Application;
using MyNexus.ApplicationRegistry.Data;
using MyNexus.ApplicationRegistry.Data.Extensions;
using System.Data.SqlClient;
using System.Reflection;

namespace MyNexus.ApplicationRegistry.IntegrationTests
{
    /// <summary>
    ///   A base class that should be used for Database related tests to setup the database.
    /// </summary>
    public abstract class DbTestBase : IDisposable
    {
        private bool isDisposed;

        /// <summary>
        ///   Initializes a new instance of the <see cref="DbTestBase"/> class.
        /// </summary>
        protected DbTestBase()
        : this(false)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="DbTestBase"/> class.
        /// </summary>
        /// <param name="includeApplicationServices">Indicates if the application services should be included.</param>
        protected DbTestBase(bool includeApplicationServices)
        {
            var fi = new FileInfo(Assembly.GetExecutingAssembly().Location);
            Configuration = TestHelper.GetIConfigurationRoot(fi.Directory?.FullName ?? String.Empty);

            // Generate Connection String using Guid for a database name so tests do not interfere with one another.
            var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString());

            builder.InitialCatalog = Guid.NewGuid().ToString();

            ConnectionString = builder.ToString();
            Configuration[$"connectionStrings:{ConnectionStrings.RegistryDb}"] = ConnectionString;

            // Add services (todo: fix ServiceCollection reference when FluentMigrator NuGet package is updated to
            // support .NET 6.0)
            var collection = Assembly.GetAssembly(typeof(IServiceCollection))?.CreateInstance("Microsoft.Extensions.DependencyInjection.ServiceCollection", false) as IServiceCollection;

            if (collection == null)
                throw new NullReferenceException("Service Collection was unable to be created.");

            var services = collection
                .AddSingleton(Configuration)
                .AddDataServices(Configuration);

            if (includeApplicationServices)
            {
                services
                    .AddSingleton<IMetrics>(new MetricsBuilder().Build())
                    .AddApplicationServices(Configuration);
            }

            ServiceProvider = services.BuildServiceProvider();

            // Generate the database
            var migrator = ServiceProvider.GetRequiredService<Migrator>();

            migrator.RunMigrations();

            // Prepare open connection for tests
            Connection = CreateOpenConnection();
        }

        /// <summary>
        ///   Gets the Configuration settings to use for the test.
        /// </summary>
        protected IConfiguration Configuration { get; private set; }

        /// <summary>
        ///   Gets the <see cref="SqlConnection"/> associated with the current test.
        /// </summary>
        protected SqlConnection Connection { get; private set; }

        /// <summary>
        ///   Gets the connection string to the test database.
        /// </summary>
        protected string ConnectionString { get; private set; }

        /// <summary>
        ///   Gets the <see cref="IServiceProvider"/>.
        /// </summary>
        protected IServiceProvider ServiceProvider { get; }

        /// <summary>
        ///   Disposes the <seealso cref="DbTestBase"/> object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///   Creates a new, open <see cref="SqlConnection"/> instance.
        /// </summary>
        /// <returns>Returns an instance of an open <see cref="SqlConnection"/> object.</returns>
        protected SqlConnection CreateOpenConnection()
        {
            var cnn = new SqlConnection(Configuration.GetConnectionString());
            cnn.Open();

            return cnn;
        }

        /// <summary>
        ///   Disposes the <seealso cref="DbTestBase"/> object.
        /// </summary>
        /// <param name="disposing">A boolean value indicating if the object is disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
                return;

            if (disposing)
            {
                Connection.Dispose();

                var migrator = ServiceProvider.GetRequiredService<Migrator>();

                migrator.DropDatabase(Configuration);
            }

            isDisposed = true;
        }
    }
}