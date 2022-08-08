using AutoMapper;
using Dapper;
using MyNexus.ApplicationRegistry.Data.Models;
using MyNexus.ApplicationRegistry.Domain.Models;
using MyNexus.ApplicationRegistry.Domain.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyNexus.ApplicationRegistry.Data.Repositories
{
    /// <summary>
    ///   A SQL Server implementation of the <see cref="IMicroApplicationRepository"/>.
    /// </summary>
    public class SqlMicroApplicationRepository : IMicroApplicationRepository
    {
        private static IMapper mapper;
        private SqlConnection cnn;

        static SqlMicroApplicationRepository()
        {
            var config = new MapperConfiguration(c =>
                c.CreateMap<MicroApplicationDataModel, MicroApplication>()
                    .ForMember(d => d.AppElementName, s => s.MapFrom(p => p.ElementName))
                    .ForMember(d => d.ScriptUrls, s => s.MapFrom(p => p.ScriptUrls.Split('|', System.StringSplitOptions.RemoveEmptyEntries)))
                    .ForMember(d => d.StyleUrls, s => s.MapFrom(p => p.StyleUrls.Split('|', System.StringSplitOptions.RemoveEmptyEntries))));

            mapper = config.CreateMapper();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SqlMicroApplicationRepository"/> class.
        /// </summary>
        /// <param name="cnn">The <see cref="IDbConnection"/> to use to execute queries.</param>
        public SqlMicroApplicationRepository(IDbConnection cnn)
        {
            this.cnn = (SqlConnection)cnn;
        }

        /// <inheritdoc/>
        public async Task<IMicroApplication> GetMicroApplicationByElementName(string tenantId, string elementName)
        {
            var app = await cnn.QueryFirstOrDefaultAsync<MicroApplicationDataModel>(
                @"
                    SELECT
                        apps.*
                    FROM
                        Registry.Application apps
                    LEFT JOIN
                        Registry.ApplicationWidgets widgets
                            ON apps.Fqan = widgets.ApplicationFqan
                    WHERE
                        (widgets.ElementName = @elementName AND widgets.ApplicationTenantId = @tenantId)
                        OR apps.ElementName = @elementName",
                new
                {
                    tenantId,
                    elementName,
                });

            if (app == null)
                return null;

            var value = mapper.Map<MicroApplication>(app);

            value.Widgets = await GetWidgets(tenantId, app.Fqan);

            return value;
        }

        public async Task<IMicroApplication> GetMicroApplicationByFqan(string tenantId, string fqan)
        {
            var app = await cnn.QueryFirstOrDefaultAsync<MicroApplicationDataModel>(
                        @"SELECT *
                        FROM Registry.Application
                        WHERE TenantId = @tenantId AND Fqan = @fqan", new { tenantId, fqan });

            if (app == null)
                return null;

            var value = mapper.Map<MicroApplication>(app);

            value.Widgets = await GetWidgets(tenantId, fqan);

            return value;
        }

        /// <inheritdoc/>
        async Task IMicroApplicationRepository.SaveMicroApplication(string tenantId, IMicroApplication application)
            => await SaveMicroApplication(tenantId, application as MicroApplication);

        /// <summary>
        ///   Saves a <see cref="MicroApplication"/> to the repository.
        /// </summary>
        /// <param name="tenantId">The id of the tenant.</param>
        /// <param name="application">The <see cref="MicroApplication"/> to save.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        public async Task SaveMicroApplication(string tenantId, MicroApplication application)
        {
            // UPSERT Application
            await cnn.ExecuteAsync(
                @"
                    MERGE Registry.Application AS apps
                    USING (SELECT @TenantId TenantId, @AppElementName ElementName, @Fqan Fqan, @ScriptUrls ScriptUrls, @StyleUrls StyleUrls) AS app
                        ON app.Fqan = apps.Fqan AND app.TenantId = @TenantId
                    WHEN MATCHED THEN UPDATE SET
                        ElementName = app.ElementName,
                        Fqan = app.Fqan,
                        ScriptUrls = app.ScriptUrls,
                        StyleUrls = app.StyleUrls
                    WHEN NOT MATCHED THEN
                        INSERT (TenantId, ElementName, Fqan, ScriptUrls, StyleUrls)
                        VALUES (@TenantId, @AppElementName, @Fqan, @ScriptUrls, @StyleUrls);
            ", new
                {
                    application.AppElementName,
                    application.Fqan,
                    ScriptUrls = string.Join("|", application.ScriptUrls),
                    StyleUrls = string.Join("|", application.StyleUrls),
                    TenantId = tenantId,
                });

            /*
             * Merge the widgets with the existing collection.
             */
            await cnn.ExecuteAsync(
                @"
                    MERGE Registry.ApplicationWidgets AS widgets
                    USING(SELECT @TenantId TenantId, @Fqan Fqan, @ElementName ElementName) AS widget
                        ON widget.TenantId = widgets.ApplicationTenantId AND widget.Fqan = widgets.ApplicationFqan AND widget.ElementName = widgets.ElementName
                    WHEN NOT MATCHED
                        THEN
                            INSERT (ApplicationTenantId, ApplicationFqan, ElementName, Description)
                            VALUES (@TenantId, @Fqan, @ElementName, @Description)
                    WHEN MATCHED
                        THEN
                            UPDATE SET Description = @Description;
                ", application.Widgets.Select(i => new
                {
                    application.Fqan,
                    TenantId = tenantId,
                    ElementName = i.Name,
                    i.Description,
                }));

            /*
             * Merge the widget tags with the existing collection.
             */
            await cnn.ExecuteAsync(
                @"
                    MERGE Registry.ApplicationWidgetTags AS widgetTags
                    USING(SELECT @TenantId TenantId, @Fqan Fqan, @ElementName ElementName, @Tag Tag) AS widget
                        ON widget.TenantId = widgetTags.ApplicationTenantId AND widget.Fqan = widgetTags.ApplicationFqan AND widget.ElementName = widgetTags.ElementName AND widget.Tag = widgetTags.Tag
                    WHEN NOT MATCHED
                        THEN INSERT (ApplicationTenantId, ApplicationFqan, ElementName, Tag)
                             VALUES (@TenantId, @Fqan, @ElementName, @Tag);
                ", application.Widgets.SelectMany(i => i.Tags.Select(tag =>
                new
                {
                    application.Fqan,
                    TenantId = tenantId,
                    ElementName = i.Name,
                    tag,
                })));

            // DELETE any records in widgets table that are not in the widgets collection.
            await cnn.ExecuteAsync("DELETE FROM Registry.ApplicationWidgets WHERE ApplicationTenantId = @TenantId AND ApplicationFqan = @Fqan AND ElementName NOT IN @ElementNames", new
            {
                TenantId = tenantId,
                application.Fqan,
                ElementNames = application.Widgets.Select(i => i.Name),
            });

            // DELETE any records in tags table that are not in the widgets collection.
            await cnn.ExecuteAsync("DELETE FROM Registry.ApplicationWidgetTags WHERE ApplicationTenantId = @TenantId AND ApplicationFqan = @Fqan AND ElementName NOT IN @ElementNames", new
            {
                TenantId = tenantId,
                application.Fqan,
                ElementNames = application.Widgets.Select(i => i.Name),
            });

            // DELETE any tags in tags table that are not in the widget tags collection.
            await Task.WhenAll(application.Widgets.Select(i =>
                cnn.ExecuteAsync("DELETE FROM Registry.ApplicationWidgetTags WHERE ApplicationTenantId = @TenantId AND ApplicationFqan = @Fqan AND ElementName = @ElementName AND Tag NOT IN @Tags", new
                {
                    TenantId = tenantId,
                    application.Fqan,
                    ElementName = i.Name,
                    i.Tags,
                })));
        }

        private async Task<IEnumerable<Widget>> GetWidgets(string tenantId, string fqan)
        {
            var widgetTags = await cnn.QueryAsync<WidgetTag>(
                @"
                    SELECT
                        widgets.ElementName,
                        tags.Tag
                    FROM
                        Registry.ApplicationWidgets widgets
                    LEFT JOIN
                        Registry.ApplicationWidgetTags tags ON
                            tags.ApplicationTenantId = widgets.ApplicationTenantId AND
                            tags.ApplicationFqan = widgets.ApplicationFqan
                    WHERE
                        widgets.ApplicationTenantId = @tenantId AND
                        widgets.ApplicationFqan = @fqan",
                new
                {
                    tenantId,
                    fqan,
                });

            var widgetIndex = widgetTags.ToLookup(i => i.ElementName);

            return widgetIndex.Select(i => new Widget
            {
                Name = i.Key,
                Tags = i.Where(j => !string.IsNullOrEmpty(j.Tag)).Select(j => j.Tag),
            });
        }

        private class WidgetTag
        {
            public string ElementName { get; set; }

            public string Tag { get; set; }
        }
    }
}