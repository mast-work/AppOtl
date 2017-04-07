namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDUSERPROPERTY : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.App_PersonModels", "UserProperty1", c => c.Int(nullable: false));
            AddColumn("dbo.App_PersonModels", "UserProperty2", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.App_PersonModels", "UserProperty2");
            DropColumn("dbo.App_PersonModels", "UserProperty1");
        }
    }
}
