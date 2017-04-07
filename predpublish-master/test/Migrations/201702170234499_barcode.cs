namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class barcode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.App_ApplicationModels", "TypeEquipment", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.App_ApplicationModels", "TypeEquipment", c => c.String());
        }
    }
}
