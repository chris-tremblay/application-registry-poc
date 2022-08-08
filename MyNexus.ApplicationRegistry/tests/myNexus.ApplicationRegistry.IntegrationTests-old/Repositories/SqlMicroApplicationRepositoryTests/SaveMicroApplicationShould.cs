using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FluentAssertions;
using MyNexus.ApplicationRegistry.Data.Repositories;
using MyNexus.ApplicationRegistry.Domain.Models;
using Xunit;

namespace MyNexus.ApplicationRegistry.IntegrationTests.Repositories.SqlMicroApplicationRepositoryTests
{
    /// <summary>
    ///   Tests for the <see
    ///   cref="Data.Repositories.SqlMicroApplicationRepository.SaveMicroApplication(MicroApplication)"/> method.
    /// </summary>
    public class SaveMicroApplicationShould : DbTestBase
    {
        /// <summary>
        ///   Ensures that a <see cref=""/> object is returned.
        /// </summary>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        [Fact]
        public async Task SaveNewRecord()
        {
            // Arrange
            var db = new SqlMicroApplicationRepository(Connection);
            var app = new MicroApplication()
            {
                AppElementName = "element-name",
                Fqan = "some.application",
                ScriptUrls = new[] { "http://example.com/script" },
                StyleUrls = new[] { "http://example.com/style" },
                Widgets = new[]
                {
                    new Widget{
                        Name = "app-element-1",
                        Description = "Descriptin 1",
                        Tags = new []{ "Tag1" }
                    },
                    new Widget{
                        Name = "app-element-2",
                        Description = "Descriptin 2",
                        Tags = new []{ "Tag1" }
                    },
                    new Widget{
                        Name = "app-element-3",
                        Description = "Descriptin 3",
                        Tags = new []{ "Tag1" }
                    },
                }
            };

            // Act
            await db.SaveMicroApplication("edf", app);

            // Assert
            using var reader = await Connection.ExecuteReaderAsync(
                @"
                    SELECT TOP 1 * FROM Registry.Application;
                    SELECT * FROM Registry.ApplicationWidgets;
                    SELECT * FROM Registry.ApplicationWidgetTags;
                ");

            await reader.ReadAsync();

            reader["TenantId"].Should().Be("edf");
            reader["ElementName"].Should().Be(app.AppElementName);
            reader["Fqan"].Should().Be(app.Fqan);
            reader["ScriptUrls"].Should().Be(string.Join("|", app.ScriptUrls));
            reader["StyleUrls"].Should().Be(string.Join("|", app.StyleUrls));

            await reader.NextResultAsync();

            var widgets = new List<Widget>(app.Widgets.Count());

            while (await reader.ReadAsync())
            {
                reader["ApplicationTenantId"].Should().Be("edf");
                reader["ApplicationFqan"].Should().Be(app.Fqan);
                widgets.Add(new Widget
                {
                    Description = reader["Description"].ToString(),
                    Name = reader["ElementName"].ToString(),
                });
            }

            await reader.NextResultAsync();

            var tags = new List<string>(app.Widgets.Count());

            while (await reader.ReadAsync())
            {
                reader["ApplicationTenantId"].Should().Be("edf");
                reader["ApplicationFqan"].Should().Be(app.Fqan);
                tags.Add(reader["Tag"].ToString());
            }

            app.Widgets.Select(i => new { i.Description, i.Name }).Should().BeEquivalentTo(widgets.Select(i => new { i.Description, i.Name }));
            app.Widgets.SelectMany(i => i.Tags).Should().BeEquivalentTo(tags);
        }

        [Fact]
        public async Task UpdateExistingRecord()
        {
            // Arrange
            var db = new SqlMicroApplicationRepository(Connection);
            var tenantId = "edf";

            var app = new MicroApplication()
            {
                AppElementName = "element-name",
                Fqan = "some.application",
                ScriptUrls = new[] { "http://example.com/script" },
                StyleUrls = new[] { "http://example.com/style" },
                Widgets = new[]
                {
                    new Widget{
                        Name = "app-element-1",
                        Description = "New Description 1",
                        Tags = new []{ "Tag1" }
                    },
                    new Widget{
                        Name = "app-element-2",
                        Description = "New Description 2",
                        Tags = new []{ "Tag1" }
                    },
                    new Widget{
                        Name = "app-element-3",
                        Description = "New Description 3",
                        Tags = new []{ "Tag1" }
                    },
                }
            };

            // INSERT existing records to be overwritten.
            await Connection.ExecuteAsync("INSERT INTO Registry.Application (TenantId, Fqan, ElementName, ScriptUrls, StyleUrls) VALUES (@TenantId, @Fqan, @ElementName, @ScriptUrls, @StyleUrls)", new
            {
                TenantId = tenantId,
                app.Fqan,
                ElementName = "old-element-name",
                ScriptUrls = "https://www.example.com/scripts",
                StyleUrls = "https://www.example.com/styles"
            });

            await Connection.ExecuteAsync("INSERT INTO Registry.ApplicationWidgets (ApplicationTenantId, ApplicationFqan, ElementName, Description) VALUES (@TenantId, @Fqan, @ElementName, @Description)", new
            {
                TenantId = tenantId,
                app.Fqan,
                ElementName = "old-element-name",
                Description = "Old Description",
            });

            await Connection.ExecuteAsync("INSERT INTO Registry.ApplicationWidgetTags (ApplicationTenantId, ApplicationFqan, ElementName, Tag) VALUES (@TenantId, @Fqan, @ElementName, @Tag)", new
            {
                TenantId = tenantId,
                app.Fqan,
                ElementName = "old-element-name",
                Tag = "Old Tag"
            });

            // Act
            await db.SaveMicroApplication("edf", app);

            // Assert
            using var reader = await Connection.ExecuteReaderAsync(
                @"
                    SELECT TOP 1 * FROM Registry.Application;
                    SELECT * FROM Registry.ApplicationWidgets;
                    SELECT * FROM Registry.ApplicationWidgetTags;
                ");

            await reader.ReadAsync();

            reader["TenantId"].Should().Be(tenantId);
            reader["ElementName"].Should().Be(app.AppElementName);
            reader["Fqan"].Should().Be(app.Fqan);
            reader["ScriptUrls"].Should().Be(string.Join("|", app.ScriptUrls));
            reader["StyleUrls"].Should().Be(string.Join("|", app.StyleUrls));

            await reader.NextResultAsync();

            var widgets = new List<Widget>(app.Widgets.Count());

            while (await reader.ReadAsync())
            {
                reader["ApplicationTenantId"].Should().Be(tenantId);
                reader["ApplicationFqan"].Should().Be(app.Fqan);
                widgets.Add(new Widget
                {
                    Description = reader["Description"].ToString(),
                    Name = reader["ElementName"].ToString(),
                });
            }

            await reader.NextResultAsync();

            var tags = new List<string>(app.Widgets.Count());

            while (await reader.ReadAsync())
            {
                reader["ApplicationTenantId"].Should().Be("edf");
                reader["ApplicationFqan"].Should().Be(app.Fqan);
                tags.Add(reader["Tag"].ToString());
            }

            app.Widgets.Select(i => new { i.Description, i.Name }).Should().BeEquivalentTo(widgets.Select(i => new { i.Description, i.Name }));
            app.Widgets.SelectMany(i => i.Tags).Should().BeEquivalentTo(tags);
        }
    }
}