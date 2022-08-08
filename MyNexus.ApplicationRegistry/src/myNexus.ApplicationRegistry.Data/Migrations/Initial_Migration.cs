using FluentMigrator;

namespace MyNexus.ApplicationRegistry.Data.Migrations
{
    /// <summary>
    ///   The initial database migration.
    /// </summary>
    [Migration(0)]
    public class Initial_Migration : ForwardOnlyMigration
    {
        public override void Up()
        {
            // Create schemas
            Create.Schema("Registry");

            // Create Tables
            Create.Table("Application").InSchema("Registry")
                .WithColumn("Id").AsInt32().Identity()
                .WithColumn("TenantId").AsString(50).PrimaryKey().NotNullable()
                .WithColumn("Fqan").AsString(150).PrimaryKey().NotNullable()
                .WithColumn("ElementName").AsString(50).NotNullable()
                .WithColumn("Name").AsString(150).NotNullable()
                .WithColumn("Icon").AsString(100).Nullable()
                .WithColumn("MenuText").AsString(30).Nullable()
                .WithColumn("RoleName").AsString(100).Nullable()
                .WithColumn("ScriptUrls").AsString(2000).NotNullable().WithColumnDescription("Pipe-Separated list")
                .WithColumn("StyleUrls").AsString(2000).Nullable().WithColumnDescription("Pipe-Separated list")
                .WithColumn("HashCode").AsString(2000).Nullable();

            Create.UniqueConstraint().OnTable("Application").WithSchema("Registry")
                .Columns("TenantId", "ElementName");

            Create.UniqueConstraint().OnTable("Application").WithSchema("Registry")
                .Columns("TenantId", "Fqan");

            Create.UniqueConstraint().OnTable("Application").WithSchema("Registry")
                .Columns("TenantId", "Name");

            Create.Table("ApplicationWidgets").InSchema("Registry")
                .WithColumn("ApplicationTenantId").AsString(50)
                .WithColumn("ApplicationFqan").AsString(150)
                .WithColumn("ElementName").AsString(50);

            Create.UniqueConstraint().OnTable("ApplicationWidgets").WithSchema("Registry")
                .Columns("ApplicationTenantId", "ElementName");

            Create.ForeignKey().FromTable("ApplicationWidgets").InSchema("Registry")
                .ForeignColumns("ApplicationTenantId", "ApplicationFqan")
                .ToTable("Application").InSchema("Registry").PrimaryColumns("TenantId", "Fqan");
        }
    }
}