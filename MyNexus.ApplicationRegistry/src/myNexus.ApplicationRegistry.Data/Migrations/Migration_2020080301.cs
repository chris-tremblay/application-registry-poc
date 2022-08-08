using FluentMigrator;

namespace MyNexus.ApplicationRegistry.Data.Migrations
{
    /// <summary>
    ///   Adds support for widget tags.
    /// </summary>
    [Migration(2020080301)]
    public class Migration_2020080301 : ForwardOnlyMigration
    {
        /// <inheritdoc/>
        public override void Up()
        {
            Create.Table("ApplicationWidgetTags").InSchema("Registry")
                .WithColumn("ApplicationTenantId").AsString(50)
                .WithColumn("ApplicationFqan").AsString(150)
                .WithColumn("ElementName").AsString(50)
                .WithColumn("Tag").AsString(50);
        }
    }
}