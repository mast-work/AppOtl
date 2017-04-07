namespace test.Migrations.ContextShipControl
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShipControl : DbMigration
    {
        public override void Up()
        {

            
            CreateTable(
                "dbo.App_ShipmentControlModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Internal_shipment_num = c.Int(nullable: false),
                        Shipment_id = c.Int(nullable: false),
                        Route_num = c.String(),
                        Ship_to = c.Int(nullable: false),
                        Tovaroved = c.Int(nullable: false),
                        Type_product = c.String(),
                        Planned_ship_date = c.DateTime(nullable: false),
                        Planned_ship_date_new = c.DateTime(nullable: false),
                        wait_volume = c.Single(nullable: false),
                        wait_weght = c.Single(nullable: false),
                        wait_rows = c.Int(nullable: false),
                        wait_plt = c.Byte(nullable: false),
                        load_volume = c.Single(nullable: false),
                        load_weght = c.Single(nullable: false),
                        load_rows = c.Int(nullable: false),
                        load_plt = c.Byte(nullable: false),
                        qty_container = c.Byte(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.App_ShipmentControlModels");
            
        }
    }
}
