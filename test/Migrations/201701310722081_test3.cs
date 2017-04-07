namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EquipmentModels", "ApplicationModels_Id", "dbo.ApplicationModels");
            DropForeignKey("dbo.PersonModels", "ApplicationModels_Id", "dbo.ApplicationModels");
            RenameColumn(table: "dbo.EquipmentModels", name: "ApplicationModels_Id", newName: "ApplicationModels_BarcodePersonGet");
            RenameColumn(table: "dbo.PersonModels", name: "ApplicationModels_Id", newName: "ApplicationModels_BarcodePersonGet");
            RenameIndex(table: "dbo.EquipmentModels", name: "IX_ApplicationModels_Id", newName: "IX_ApplicationModels_BarcodePersonGet");
            RenameIndex(table: "dbo.PersonModels", name: "IX_ApplicationModels_Id", newName: "IX_ApplicationModels_BarcodePersonGet");
            DropPrimaryKey("dbo.ApplicationModels");
            DropPrimaryKey("dbo.EquipmentModels");
            DropPrimaryKey("dbo.PersonModels");
            AlterColumn("dbo.ApplicationModels", "BarcodePersonGet", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.EquipmentModels", "BarcodeEquipment", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PersonModels", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.PersonModels", "BarcodePerson", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ApplicationModels", "BarcodePersonGet");
            AddPrimaryKey("dbo.EquipmentModels", "BarcodeEquipment");
            AddPrimaryKey("dbo.PersonModels", "BarcodePerson");
            AddForeignKey("dbo.EquipmentModels", "ApplicationModels_BarcodePersonGet", "dbo.ApplicationModels", "BarcodePersonGet");
            AddForeignKey("dbo.PersonModels", "ApplicationModels_BarcodePersonGet", "dbo.ApplicationModels", "BarcodePersonGet");
            DropColumn("dbo.ApplicationModels", "Id");
            DropColumn("dbo.EquipmentModels", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EquipmentModels", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ApplicationModels", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.PersonModels", "ApplicationModels_BarcodePersonGet", "dbo.ApplicationModels");
            DropForeignKey("dbo.EquipmentModels", "ApplicationModels_BarcodePersonGet", "dbo.ApplicationModels");
            DropPrimaryKey("dbo.PersonModels");
            DropPrimaryKey("dbo.EquipmentModels");
            DropPrimaryKey("dbo.ApplicationModels");
            AlterColumn("dbo.PersonModels", "BarcodePerson", c => c.Int(nullable: false));
            AlterColumn("dbo.PersonModels", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.EquipmentModels", "BarcodeEquipment", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationModels", "BarcodePersonGet", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PersonModels", "Id");
            AddPrimaryKey("dbo.EquipmentModels", "Id");
            AddPrimaryKey("dbo.ApplicationModels", "Id");
            RenameIndex(table: "dbo.PersonModels", name: "IX_ApplicationModels_BarcodePersonGet", newName: "IX_ApplicationModels_Id");
            RenameIndex(table: "dbo.EquipmentModels", name: "IX_ApplicationModels_BarcodePersonGet", newName: "IX_ApplicationModels_Id");
            RenameColumn(table: "dbo.PersonModels", name: "ApplicationModels_BarcodePersonGet", newName: "ApplicationModels_Id");
            RenameColumn(table: "dbo.EquipmentModels", name: "ApplicationModels_BarcodePersonGet", newName: "ApplicationModels_Id");
            AddForeignKey("dbo.PersonModels", "ApplicationModels_Id", "dbo.ApplicationModels", "Id");
            AddForeignKey("dbo.EquipmentModels", "ApplicationModels_Id", "dbo.ApplicationModels", "Id");
        }
    }
}
