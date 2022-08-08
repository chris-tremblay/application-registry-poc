using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Data.Queries.GetCorsAllowedOrigins
{
    /// <summary>
    ///   A Sql Implementation of the <see cref="IProvideGetCorsAllowedOriginsQueryData"/> interface.
    /// </summary>
    public class SqlCorsAllowedOriginsDataProvider : IProvideGetCorsAllowedOriginsQueryData
    {
        private readonly SqlConnection cnn;
        private readonly TenantId tenantId;

        /// <summary>
        ///   Initializes a new instance of the <see cref="SqlCorsAllowedOriginsDataProvider"/> class.
        /// </summary>
        /// <param name="cnn">The <see cref="SqlConnection"/> instance.</param>
        /// <param name="tenantId">The tenant identifier.</param>
        public SqlCorsAllowedOriginsDataProvider(IDbConnection cnn, TenantId tenantId)
        {
            this.cnn = (SqlConnection)cnn;
            this.tenantId = tenantId;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<string>> GetScriptUrls()
            => await cnn.QueryAsync<string>("SELECT ScriptUrls FROM [Registry].Application WHERE TenantId = @tenantId;", new { tenantId = tenantId.Value });
    }
}