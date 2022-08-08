using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Data.Queries.GetApplicationsElementList
{
    public class SqlGetApplicationsElementListQueryDataProvider : IProvideGetApplicationsElementListQueryData
    {
        private SqlConnection cnn;
        private TenantId tenantId;

        public SqlGetApplicationsElementListQueryDataProvider(TenantId tenantId, IDbConnection cnn)
        {
            this.cnn = (SqlConnection)cnn;
            this.tenantId = tenantId;
        }

        public async Task<IEnumerable<string>> GetApplicationsElementNames()
            => await cnn.QueryAsync<string>(
                @$"
                    SELECT
                        ElementName
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