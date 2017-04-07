namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonModels", "BarcodePersonAll", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonModels", "BarcodePersonAll");
        }
    }
}
