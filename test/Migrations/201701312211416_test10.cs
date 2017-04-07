namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test10 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PersonModels", "BarcodePersonAll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonModels", "BarcodePersonAll", c => c.String(nullable: false));
        }
    }
}
