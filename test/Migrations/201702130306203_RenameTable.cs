namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationModels", newName: "App_ApplicationModels");
            RenameTable(name: "dbo.EquipmentModels", newName: "App_EquipmentModels");
            RenameTable(name: "dbo.PersonModels", newName: "App_PersonModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.App_PersonModels", newName: "PersonModels");
            RenameTable(name: "dbo.App_EquipmentModels", newName: "EquipmentModels");
            RenameTable(name: "dbo.App_ApplicationModels", newName: "ApplicationModels");
        }
    }
}
