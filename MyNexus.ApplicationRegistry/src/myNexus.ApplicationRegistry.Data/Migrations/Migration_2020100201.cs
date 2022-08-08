using FluentMigrator;

namespace MyNexus.ApplicationRegistry.Data.Migrations
{
    /// <summary>
    ///   Adds DevServices table.
    /// </summary>
    [Migration(2020100201)]
    public class Migration_2020100201 : ForwardOnlyMigration
    {
        /// <inheritdoc/>
        public override void Up()
        {
            Create.Table("ServiceDomain").InSchema("Registry")
                .WithColumn("TenantId").AsAnsiString(50).NotNullable().PrimaryKey()
                .WithColumn("ServiceDomain").AsAnsiString(250).NotNullable().PrimaryKey();
        }
    }
}