namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EquipmentModels", "ApplicationModels_BarcodePersonGet", "dbo.ApplicationModels");
            DropForeignKey("dbo.PersonModels", "ApplicationModels_BarcodePersonGet", "dbo.ApplicationModels");
            RenameColumn(table: "dbo.EquipmentModels", name: "ApplicationModels_BarcodePersonGet", newName: "ApplicationModels_Id");
            RenameColumn(table: "dbo.PersonModels", name: "ApplicationModels_BarcodePersonGet", newName: "ApplicationModels_Id");
            RenameIndex(table: "dbo.EquipmentModels", name: "IX_ApplicationModels_BarcodePersonGet", newName: "IX_ApplicationModels_Id");
            RenameIndex(table: "dbo.PersonModels", name: "IX_ApplicationModels_BarcodePersonGet", newName: "IX_ApplicationModels_Id");
            DropPrimaryKey("dbo.ApplicationModels");
            DropPrimaryKey("dbo.EquipmentModels");
            DropPrimaryKey("dbo.PersonModels");
            AddColumn("dbo.ApplicationModels", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.EquipmentModels", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.PersonModels", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ApplicationModels", "BarcodePersonGet", c => c.Int(nullable: false));
            AlterColumn("dbo.EquipmentModels", "BarcodeEquipment", c => c.Int(nullable: false));
            AlterColumn("dbo.PersonModels", "BarcodePerson", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ApplicationModels", "Id");
            AddPrimaryKey("dbo.EquipmentModels", "Id");
            AddPrimaryKey("dbo.PersonModels", "Id");
            AddForeignKey("dbo.EquipmentModels", "ApplicationModels_Id", "dbo.ApplicationModels", "Id");
            AddForeignKey("dbo.PersonModels", "ApplicationModels_Id", "dbo.ApplicationModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonModels", "ApplicationModels_Id", "dbo.ApplicationModels");
            DropForeignKey("dbo.EquipmentModels", "ApplicationModels_Id", "dbo.ApplicationModels");
            DropPrimaryKey("dbo.PersonModels");
            DropPrimaryKey("dbo.EquipmentModels");
            DropPrimaryKey("dbo.ApplicationModels");
            AlterColumn("dbo.PersonModels", "BarcodePerson", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.EquipmentModels", "BarcodeEquipment", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ApplicationModels", "BarcodePersonGet", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.PersonModels", "Id");
            DropColumn("dbo.EquipmentModels", "Id");
            DropColumn("dbo.ApplicationModels", "Id");
            AddPrimaryKey("dbo.PersonModels", "BarcodePerson");
            AddPrimaryKey("dbo.EquipmentModels", "BarcodeEquipment");
            AddPrimaryKey("dbo.ApplicationModels", "BarcodePersonGet");
            RenameIndex(table: "dbo.PersonModels", name: "IX_ApplicationModels_Id", newName: "IX_ApplicationModels_BarcodePersonGet");
            RenameIndex(table: "dbo.EquipmentModels", name: "IX_ApplicationModels_Id", newName: "IX_ApplicationModels_BarcodePersonGet");
            RenameColumn(table: "dbo.PersonModels", name: "ApplicationModels_Id", newName: "ApplicationModels_BarcodePersonGet");
            RenameColumn(table: "dbo.EquipmentModels", name: "ApplicationModels_Id", newName: "ApplicationModels_BarcodePersonGet");
            AddForeignKey("dbo.PersonModels", "ApplicationModels_BarcodePersonGet", "dbo.ApplicationModels", "BarcodePersonGet");
            AddForeignKey("dbo.EquipmentModels", "ApplicationModels_BarcodePersonGet", "dbo.ApplicationModels", "BarcodePersonGet");
        }
    }
}
