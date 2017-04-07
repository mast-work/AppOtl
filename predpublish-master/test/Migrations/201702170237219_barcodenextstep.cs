namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class barcodenextstep : DbMigration
    {
        public override void Up()
        {
            CreateTable(
            "dbo.App_BarcodeItem",
            c => new
            {
                Id = c.Int(nullable: false, identity: true),
                Barcode = c.Int(nullable: false),
                Item = c.Int(nullable: false)                
            })
            .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
        }
    }
}
