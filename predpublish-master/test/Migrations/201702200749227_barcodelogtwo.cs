namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class barcodelogtwo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                            "dbo.App_BarcodeLog",
                            c => new
                            {
                                Id = c.Int(nullable: false, identity: true),
                                Barcode = c.String(),
                                DateAdd = c.DateTime(nullable: false),
                            })
                            .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
        }
    }
}
