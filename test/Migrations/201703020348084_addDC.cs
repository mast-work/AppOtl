namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.App_ApplicationModels", "DC", c => c.Int(nullable: false));
            AddColumn("dbo.App_EquipmentModels", "DC", c => c.Int(nullable: false));
            AddColumn("dbo.App_PersonModels", "DC", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.App_PersonModels", "DC");
            DropColumn("dbo.App_EquipmentModels", "DC");
            DropColumn("dbo.App_ApplicationModels", "DC");
        }
    }
}
