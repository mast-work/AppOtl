namespace test.Migrations.ContextShipControl
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShipControlDC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.App_ShipmentControlModels", "DC", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.App_ShipmentControlModels", "DC");
        }
    }
}
