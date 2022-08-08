using System.Threading.Tasks;
using Dapper;
using FluentAssertions;
using MyNexus.ApplicationRegistry.Data;
using MyNexus.ApplicationRegistry.Data.Queries.ElementSearch;
using Xunit;

namespace MyNexus.ApplicationRegistry.IntegrationTests.Queries.ElementSearch.SqlElementSearchQueryDataProviderTests
{
    public class GetElementsShould : DbTestBase
    {
        [Fact]
        public async Task QueryElementByApplicationName()
        {
            // Arrange
            var provider = new SqlElementSearchQueryDataProvider(new TenantId("tenant 1"), Connection);

            await SeedDatabase();

            // Act
            var results = await provider.GetElements("app1", null, null);

            // Assert
            results.Should().HaveCount(2);
        }

        [Fact]
        public async Task QueryElementByElementName()
        {
            // Arrange
            var provider = new SqlElementSearchQueryDataProvider(new TenantId("tenant 1"), Connection);

            await SeedDatabase();

            // Act
            var results = await provider.GetElements(null, "element-1", null);

            // Assert
            results.Should().HaveCount(1);
        }

        [Fact]
        public async Task QueryElementByTags()
        {
            // Arrange
            var provider = new SqlElementSearchQueryDataProvider(new TenantId("tenant 1"), Connection);

            await SeedDatabase();

            // Act
            var results = await provider.GetElements(null, null, new[] { "Control" });

            // Assert
            results.Should().HaveCount(1);
        }

        private async Task SeedDatabase()
        {
            await Connection.ExecuteAsync("INSERT INTO Registry.Application (TenantId, Fqan, ElementName, ScriptUrls) VALUES (@TenantId, @Fqan, @ElementName, @ScriptUrls)", new[] {
                new {
                    TenantId = "tenant 1",
                    Fqan = "services.app1",
                    ElementName = "app-1",
                    ScriptUrls = "http://some.domain.com"
                } ,
                new {
                    TenantId = "tenant 1",
                    Fqan = "services.app2",
                    ElementName = "app-2",
                    ScriptUrls = "http://some.domain.com"
                },
                new {
                    TenantId = "tenant 2",
                    Fqan = "services.app1",
                    ElementName = "app-1",
                    ScriptUrls = "http://some.domain.com"
                }});

            await Connection.ExecuteAsync("INSERT INTO Registry.ApplicationWidgets (ApplicationTenantId, ApplicationFqan, ElementName, Description) VALUES (@ApplicationTenantId, @ApplicationFqan, @ElementName, @Description)", new[] {
                new {
                    ApplicationTenantId = "tenant 1",
                    ApplicationFqan = "services.app1",
                    ElementName = "element-1",
                    Description = "Some cool element."
                },
                new {
                    ApplicationTenantId = "tenant 1",
                    ApplicationFqan = "services.app1",
                    ElementName = "element-2",
                    Description = "Some cool element."
                },
                new {
                    ApplicationTenantId = "tenant 1",
                    ApplicationFqan = "services.app2",
                    ElementName = "element-3",
                    Description = "Some cool element."
                },
                new {
                    ApplicationTenantId = "tenant 2",
                    ApplicationFqan = "services.app1",
                    ElementName = "element-1",
                    Description = "Some cool element."
                }
                });

            await Connection.ExecuteAsync("INSERT INTO Registry.ApplicationWidgetTags (ApplicationTenantId, ApplicationFqan, ElementName, Tag) VALUES (@ApplicationTenantId, @ApplicationFqan, @ElementName, @Tag)", new[] {
                new {
                    ApplicationTenantId = "tenant 1",
                    ApplicationFqan = "services.app1",
                    ElementName = "element-1",
                    Tag = "Control",
                },
                new {
                    ApplicationTenantId = "tenant 1",
                    ApplicationFqan = "services.app1",
                    ElementName = "element-1",
                    Tag = "Dashboard",
                },
                new {
                    ApplicationTenantId = "tenant 1",
                    ApplicationFqan = "services.app1",
                    ElementName = "element-1",
                    Tag = "Billing",
                },
                new {
                    ApplicationTenantId = "tenant 1",
                    ApplicationFqan = "services.app2",
                    ElementName = "element-2",
                    Tag = "Tag 1",
                },
                new {
                    ApplicationTenantId = "tenant 2",
                    ApplicationFqan = "services.app1",
                    ElementName = "element-1",
                    Tag = "Tag 1",
                }});
        }
    }
}