namespace test.Migrations.ContextShipControl
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShipControlDCShort : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.App_ShipmentControlModels", "DC", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.App_ShipmentControlModels", "DC", c => c.Byte(nullable: false));
        }
    }
}
