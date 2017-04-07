namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EquipmentModels", "ApplicationModels_Id", "dbo.ApplicationModels");
            DropForeignKey("dbo.PersonModels", "ApplicationModels_Id", "dbo.ApplicationModels");
            DropIndex("dbo.EquipmentModels", new[] { "ApplicationModels_Id" });
            DropIndex("dbo.PersonModels", new[] { "ApplicationModels_Id" });
            //DropColumn("dbo.EquipmentModels", "ApplicationModels_Id");
            //DropColumn("dbo.PersonModels", "ApplicationModels_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonModels", "ApplicationModels_Id", c => c.Int());
            AddColumn("dbo.EquipmentModels", "ApplicationModels_Id", c => c.Int());
            CreateIndex("dbo.PersonModels", "ApplicationModels_Id");
            CreateIndex("dbo.EquipmentModels", "ApplicationModels_Id");
            //AddForeignKey("dbo.PersonModels", "ApplicationModels_Id", "dbo.ApplicationModels", "Id");
            //AddForeignKey("dbo.EquipmentModels", "ApplicationModels_Id", "dbo.ApplicationModels", "Id");
        }
    }
}
