namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationModels",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    BarcodePersonGet = c.Int(nullable: false),
                    BarcodePersonSet = c.Int(nullable: false),
                    BarcodeEquipment = c.Int(nullable: false),
                    GetTime = c.DateTime(nullable: false),
                    SetTime = c.DateTime(nullable: false),
                    Comment = c.String(),
                })
                .PrimaryKey(t => t.Id);
                //.ForeignKey("dbo.PersonModels", t => t.ApplicationModels_Id1)
                //.Index(t => t.ApplicationModels_Id1);

            CreateTable(
                "dbo.EquipmentModels",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    BarcodeEquipment = c.Int(nullable: false),
                    SerialNumberEquipment = c.String(),
                    NameEquipment = c.String(),                                        
                })
                .PrimaryKey(t => t.Id);


            CreateTable(
                "dbo.PersonModels",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    BarcodePerson = c.Int(nullable: false),
                    NamePerson = c.String(),                   
                })
                .PrimaryKey(t => t.Id);
                //.ForeignKey("dbo.ApplicationModels", t => t.ApplicationModels_Id1)
                //.Index(t => t.ApplicationModels_Id1);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.PersonModels", "ApplicationModels_Id1", "dbo.ApplicationModels");
            //DropForeignKey("dbo.EquipmentModels", "ApplicationModels_Id1", "dbo.ApplicationModels");
            //DropIndex("dbo.PersonModels", new[] { "ApplicationModels_Id1" });
            //DropIndex("dbo.EquipmentModels", new[] { "ApplicationModels_Id1" });
            //DropTable("dbo.PersonModels");
            //DropTable("dbo.EquipmentModels");
            //DropTable("dbo.ApplicationModels");
        }
    }
}
