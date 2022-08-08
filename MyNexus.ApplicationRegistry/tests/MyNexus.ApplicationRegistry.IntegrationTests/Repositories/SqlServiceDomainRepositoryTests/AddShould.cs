using Dapper;
using FluentAssertions;
using MyNexus.ApplicationRegistry.Data;
using MyNexus.ApplicationRegistry.Data.Repositories;
using Xunit;

namespace MyNexus.ApplicationRegistry.IntegrationTests.Repositories.V2.SqlServiceDomainRepositoryTests
{
    public class AddShould : DbTestBase
    {
        [Fact]
        public async Task Add()
        {
            // Arrange
            var tenantId = new TenantId("Tenant1");
            var repository = new SqlServiceDomainRepository(Connection, tenantId);

            // Act
            await repository.Add("http://service1.domain.com");

            // Assert
            (await Connection.QueryAsync("SELECT * FROM Registry.ServiceDomain WHERE TenantId = @tenantId", new
            {
                tenantId = tenantId.Value,
            })).Should().HaveCount(1);
        }
    }
}