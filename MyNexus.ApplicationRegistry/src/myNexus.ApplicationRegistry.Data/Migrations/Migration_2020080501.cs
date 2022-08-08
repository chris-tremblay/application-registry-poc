using FluentMigrator;

namespace MyNexus.ApplicationRegistry.Data.Migrations
{
    /// <summary>
    ///   Adds Description column to the widgets ApplicationWidgets table.
    /// </summary>
    [Migration(2020080501)]
    public class Migration_2020080501 : ForwardOnlyMigration
    {
        /// <inheritdoc/>
        public override void Up()
        {
            Alter.Table("ApplicationWidgets").InSchema("Registry")
                .AddColumn("Description").AsString(200).Nullable();
        }
    }
}