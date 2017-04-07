namespace test.Migrations.ContextBarcode
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShipControl : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.App_BarcodeLoc",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false),
                        Barcode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
                      
        }
        
        public override void Down()
        {           
            DropTable("dbo.App_BarcodeLoc");
        }
    }
}
