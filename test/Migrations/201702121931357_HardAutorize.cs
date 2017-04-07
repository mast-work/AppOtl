namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HardAutorize : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "App_UserRole");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.App_UserRole", newName: "Users");
        }
    }
}
