using FluentMigrator;

namespace MyNexus.ApplicationRegistry.Data.Migrations
{
    /// <summary>
    ///   The initial database migration.
    /// </summary>
    [Migration(2019121201)]
    public class Migration_2019121201 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Delete.UniqueConstraint().FromTable("Application").InSchema("Registry")
                .Columns("TenantId", "Name");

            Delete.Column("Icon").FromTable("Application").InSchema("Registry");
            Delete.Column("MenuText").FromTable("Application").InSchema("Registry");
            Delete.Column("Name").FromTable("Application").InSchema("Registry");
            Delete.Column("RoleName").FromTable("Application").InSchema("Registry");
        }
    }
}