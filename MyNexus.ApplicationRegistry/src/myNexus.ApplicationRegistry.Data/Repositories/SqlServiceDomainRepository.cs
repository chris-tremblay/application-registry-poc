using Dapper;
using MyNexus.ApplicationRegistry.Domain.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Data.Repositories
{
    /// <summary>
    ///   A sql server implementation of the <see cref="IServiceDomainRepository"/>.
    /// </summary>
    public class SqlServiceDomainRepository : IServiceDomainRepository
    {
        private readonly SqlConnection cnn;
        private readonly TenantId tenantId;

        /// <summary>
        ///   Initializes a new instance of the <see cref="SqlServiceDomainRepository"/> class.
        /// </summary>
        /// <param name="cnn">The <see cref="IDbConnection"/> to use to execute queries.</param>
        /// <param name="tenantId">The <see cref="TenantId"/>.</param>
        public SqlServiceDomainRepository(IDbConnection cnn, TenantId tenantId)
        {
            this.cnn = (SqlConnection)cnn;
            this.tenantId = tenantId;
        }

        /// <inheritdoc/>
        public Task Add(string serviceDomain)
            => cnn.ExecuteAsync("IF NOT EXISTS (SELECT * FROM Registry.ServiceDomain WHERE ServiceDomain = @serviceDomain AND TenantId = @tenantId) INSERT INTO Registry.ServiceDomain (TenantId, ServiceDomain) VALUES (@tenantId, @serviceDomain)", new
            {
                serviceDomain,
                tenantId = tenantId.Value,
            });

        /// <inheritdoc/>
        public Task<IEnumerable<string>> GetAll()
            => cnn.QueryAsync<string>("SELECT ServiceDomain FROM Registry.ServiceDomain WHERE TenantId = @tenantId", new
            {
                tenantId = tenantId.Value,
            });
    }
}