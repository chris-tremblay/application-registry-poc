using Dapper;
using FluentAssertions;
using MyNexus.ApplicationRegistry.Data.Repositories;
using MyNexus.ApplicationRegistry.Domain.Models;
using Xunit;

namespace MyNexus.ApplicationRegistry.IntegrationTests.Repositories.SqlMicroApplicationRepositoryTests
{
    public class GetMicroApplicationByFqanShould : DbTestBase
    {
        public GetMicroApplicationByFqanShould() : base(false)
        {
        }

        [Fact]
        public async Task ReturnMicroApplication()
        {
            // Arrange
            var db = new SqlMicroApplicationRepository(Connection);
            var tenantId = "Tenant 1";
            var insertedApp = new MicroApplication()
            {
                Fqan = "some.app",
                AppElementName = "element-name",
            };

            await Connection.ExecuteAsync("INSERT INTO [Registry].[Application] (TenantId, Fqan, ElementName, ScriptUrls, StyleUrls) VALUES(@tenantId, @Fqan, @AppElementName, @ScriptUrls, @StyleUrls)", new
            {
                tenantId,
                insertedApp.Fqan,
                insertedApp.AppElementName,
                ScriptUrls = "https://www.example.com/script|https://www.example.com/script2",
                StyleUrls = "https://www.example.com/style|https://www.example.com/style2|https://www.example.com/style3"
            });

            await Connection.ExecuteAsync("INSERT INTO [Registry].[ApplicationWidgets] (ApplicationTenantId, ApplicationFqan, ElementName) VALUES(@tenantId, @Fqan, @AppElementName)", new[] {
                new
                {
                    tenantId,
                    insertedApp.Fqan,
                    insertedApp.AppElementName
                },
                new
                {
                    tenantId,
                    insertedApp.Fqan,
                    AppElementName = "app-element-2",
                }
            });

            // Act
            var app = (await db.GetMicroApplicationByFqan("Tenant 1", insertedApp.Fqan)) as MicroApplication;

            // Assert

            app.Should().NotBeNull();
            app?.AppElementName.Should().BeEquivalentTo(insertedApp.AppElementName);
            app?.Fqan.Should().BeEquivalentTo(insertedApp.Fqan);
            app?.ScriptUrls.Should().HaveCount(2);
            app?.StyleUrls.Should().HaveCount(3);
            app?.Widgets.Should().HaveCount(2);
        }

        [Fact]
        public async Task ReturnNull()
        {
            // Arrange
            var db = new SqlMicroApplicationRepository(Connection);

            // Act
            var app = await db.GetMicroApplicationByFqan("Tenant 1", "element-name");

            // Assert

            app.Should().BeNull();
        }
    }
}