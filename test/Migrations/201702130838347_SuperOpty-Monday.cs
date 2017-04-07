namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuperOptyMonday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.App_ApplicationModels", "TypeEquipment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.App_ApplicationModels", "TypeEquipment");
        }
    }
}
