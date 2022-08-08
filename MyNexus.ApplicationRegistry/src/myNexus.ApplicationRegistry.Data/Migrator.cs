using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyNexus.ApplicationRegistry.Data.Extensions;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MyNexus.ApplicationRegistry.Data
{
    /// <summary>
    ///   The class that is responsible for running data migrations.
    /// </summary>
    public class Migrator
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<Migrator> logger;
        private readonly IMigrationRunner migrationRunner;

        /// <summary>
        ///   Initializes a new instance of the <see cref="Migrator"/> class.
        /// </summary>
        /// <param name="configuration">The application configuration settings.</param>
        /// <param name="migrationRunner">The migration runner.</param>
        /// <param name="logger">A <see cref="ILogger"/>.</param>
        public Migrator(IConfiguration configuration, ILogger<Migrator> logger, IMigrationRunner migrationRunner)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.migrationRunner = migrationRunner;
        }

        /// <summary>
        ///   Runs all new migrations.
        /// </summary>
        public void RunMigrations()
        {
            try
            {
                CreateOrRecreateDb();

                logger.LogInformation("Migrating database...");

                migrationRunner.MigrateUp();
            }
            catch (Exception e)
            {
#if DEBUG
                Debugger.Break();
#endif
                logger.LogError(e, "ERROR running data migrations!");
                throw;
            }
        }

        internal void DropDatabase(IConfiguration configuration)
        {
            var databaseName = configuration.GetDatabaseName();
            var connectionString = configuration.GetMasterDatabaseConnectionString();
            var commandText = $@"
                ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
                DROP DATABASE IF EXISTS [{databaseName}]
            ";

            logger.LogInformation("Dropping Databse [{databaseName}]...", databaseName);

            ExecuteNonQuery(commandText, connectionString);
        }

        internal void DropDatabase()
            => DropDatabase(configuration);

        private static int ExecuteNonQuery(string commandText, string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = CommandType.Text;

                    return command.ExecuteNonQuery();
                }
            }
        }

        private void CreateDatabase()
        {
            var databaseName = configuration.GetDatabaseName();
            var connectionString = configuration.GetMasterDatabaseConnectionString();

            logger.LogInformation("Creating database...");

            ExecuteNonQuery($"IF (db_id(N'{databaseName}') IS NULL) CREATE DATABASE [{databaseName}]", connectionString);
        }

        private void CreateOrRecreateDb()
        {
#if DEBUG
            if (configuration["RecreateDB"]?.Equals("true", StringComparison.OrdinalIgnoreCase) ?? false)
                DropDatabase();
#endif
            CreateDatabase();
        }
    }
}