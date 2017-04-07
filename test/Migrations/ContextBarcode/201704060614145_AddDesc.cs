namespace test.Migrations.ContextBarcode
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDesc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.App_BarcodeItem", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.App_BarcodeItem", "Description");
        }
    }
}
