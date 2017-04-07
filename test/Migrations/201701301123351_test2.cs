namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EquipmentModels", "SerialNumberEquipment", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.EquipmentModels", "NameEquipment", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.PersonModels", "NamePerson", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonModels", "NamePerson", c => c.String(maxLength: 50));
            AlterColumn("dbo.EquipmentModels", "NameEquipment", c => c.String(maxLength: 100));
            AlterColumn("dbo.EquipmentModels", "SerialNumberEquipment", c => c.String(maxLength: 100));
        }
    }
}
