using System.Threading.Tasks;
using Dapper;
using FluentAssertions;
using MyNexus.ApplicationRegistry.Data;
using MyNexus.ApplicationRegistry.Data.Repositories;
using Xunit;

namespace MyNexus.ApplicationRegistry.IntegrationTests.Repositories.SqlServiceDomainRepositoryTests
{
    public class GetAllShould : DbTestBase
    {
        [Fact]
        public async Task ReturnList()
        {
            // Arrange
            var repository = new SqlServiceDomainRepository(Connection, new TenantId("Tenant1"));

            await SeedDatabase();

            // Act
            var domains = await repository.GetAll();

            // Assert
            domains.Should().HaveCount(3);
        }

        private async Task SeedDatabase()
            => await Connection.ExecuteAsync("INSERT INTO Registry.ServiceDomain (TenantId, ServiceDomain) VALUES (@tenantId, @serviceDomain);", new[]
            {
                new {
                    tenantid = "Tenant1",
                    serviceDomain = "http://service1.domain.com:13400",
                },
                new {
                    tenantid = "Tenant1",
                    serviceDomain = "http://service2.domain.com:13401",
                },
                new {
                    tenantid = "Tenant1",
                    serviceDomain = "http://service3.domain.com:13402",
                },
                new {
                    tenantid = "Tenant2",
                    serviceDomain = "http://service1.domain.com:13400",
                },
            });
    }
}