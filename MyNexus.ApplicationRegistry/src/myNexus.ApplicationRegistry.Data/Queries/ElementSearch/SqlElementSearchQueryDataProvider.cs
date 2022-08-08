using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Data.Queries.ElementSearch
{
    /// <summary>
    ///   A Sql Server implementation of the <see cref="IProvideElementSearchQueryData"/> interface.
    /// </summary>
    public class SqlElementSearchQueryDataProvider : IProvideElementSearchQueryData
    {
        private SqlConnection cnn;
        private TenantId tenantId;

        /// <summary>
        ///   Initializes a new instance of the <see cref="SqlElementSearchQueryDataProvider"/> class.
        /// </summary>
        /// <param name="tenantId">The <see cref="TenantId"/>.</param>
        /// <param name="cnn">The <see cref="SqlConnection"/> to the database.</param>
        public SqlElementSearchQueryDataProvider(TenantId tenantId, IDbConnection cnn)
        {
            this.tenantId = tenantId;
            this.cnn = (SqlConnection)cnn;
        }

        [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:Closing brace should be followed by blank line", Justification = "Inline string")]
        public async Task<IEnumerable<ElementSearchQueryResult>> GetElements(string applicationName, string elementName, IEnumerable<string> tags)
            => await cnn.QueryAsync<ElementSearchQueryResult>(
                @$"
                    SELECT
                        Fqan AS ApplicationName,
                        widgets.Description,
                        widgets.ElementName
                    FROM
                        Registry.Application apps
                    LEFT JOIN
                        Registry.ApplicationWidgets widgets
                            ON apps.TenantId = widgets.ApplicationTenantId AND apps.Fqan = widgets.ApplicationFqan
                    {(tags?.Any() == true ?
                        @"INNER JOIN
                            (SELECT DISTINCT ElementName, ApplicationFqan FROM Registry.ApplicationWidgetTags WHERE Tag IN @tags AND ApplicationTenantId = @tenantId) tags
                                ON apps.Fqan = tags.ApplicationFqan AND widgets.ElementName = tags.ElementName"
                        : string.Empty)}
                    WHERE
                        apps.TenantId = @tenantId AND
                        Fqan LIKE @applicationName AND
                        widgets.ElementName LIKE @elementName
                ",
                new
                {
                    applicationName = $"%{applicationName}%",
                    elementName = $"%{elementName}%",
                    tags,
                    tenantId = tenantId.Value,
                });
    }
}