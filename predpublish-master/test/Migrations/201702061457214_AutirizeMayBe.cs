namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutirizeMayBe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationModels", "UserGet", c => c.String(nullable: false));
            AddColumn("dbo.ApplicationModels", "UserSet", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationModels", "UserSet");
            DropColumn("dbo.ApplicationModels", "UserGet");
        }
    }
}
