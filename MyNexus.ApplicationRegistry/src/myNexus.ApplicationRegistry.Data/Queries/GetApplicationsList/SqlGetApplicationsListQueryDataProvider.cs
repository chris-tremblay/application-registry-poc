using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Data.Queries.GetApplicationsList
{
    public class SqlGetApplicationsListQueryDataProvider : IProvideGetApplicationsListQueryData
    {
        private SqlConnection cnn;
        private TenantId tenantId;

        public SqlGetApplicationsListQueryDataProvider(TenantId tenantId, IDbConnection cnn)
        {
            this.cnn = (SqlConnection)cnn;
            this.tenantId = tenantId;
        }

        public async Task<IEnumerable<string>> GetApplicationNames()
            => await cnn.QueryAsync<string>(
                @$"
                    SELECT
                        Fqan AS ApplicationName
                    FROM
                        Registry.Application
                    WHERE
                        TenantId = @tenantId
                ",
                new
                {
                    tenantId = tenantId.Value,
                });
    }
}