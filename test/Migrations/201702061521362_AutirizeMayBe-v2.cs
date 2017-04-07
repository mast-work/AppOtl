namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutirizeMayBev2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplicationModels", "UserGet", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplicationModels", "UserGet", c => c.String(nullable: false));
        }
    }
}
