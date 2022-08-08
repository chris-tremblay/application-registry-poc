using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace MyNexus.ApplicationRegistry.Data.Extensions
{
    /// <summary>
    ///   A static helper class for dealing with connection strings.
    /// </summary>
    public static class ConnectionStrings
    {
        /// <summary>
        ///   Defines the name of the primary connection string.
        /// </summary>
        public const string RegistryDb = "MyNexus.ApplicationRegistry.Data";

        /// <summary>
        ///   Gets the value of the primary connection string.
        /// </summary>
        /// <param name="configuration">
        ///   An <seealso cref="IConfiguration"/> object containing the application configuration settings.
        /// </param>
        /// <returns>
        ///   Returns the connection string for the default database from the <seealso cref="IConfiguration"/> object.
        /// </returns>
        public static string GetConnectionString(this IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(RegistryDb);

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"The connection string '{RegistryDb}' was not found.");

            return connectionString;
        }

        /// <summary>
        ///   This method used by the data migrations.
        /// </summary>
        /// <param name="configuration">
        ///   An <seealso cref="IConfiguration"/> object containing the application configuration settings.
        /// </param>
        /// <returns>Returns the database name from an <seealso cref="IConfiguration"/> object.</returns>
        internal static string GetDatabaseName(this IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString();
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            return connectionStringBuilder.InitialCatalog;
        }

        /// <summary>
        ///   This method used by the data migrations.
        /// </summary>
        /// <param name="configuration">
        ///   An <seealso cref="IConfiguration"/> object containing the application configuration settings.
        /// </param>
        /// <returns>
        ///   Returns the connection string to the master database from the <seealso cref="IConfiguration"/> object.
        /// </returns>
        internal static string GetMasterDatabaseConnectionString(this IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString();
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = "master",
            };

            return connectionStringBuilder.ConnectionString;
        }
    }
}