namespace ArduinoControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDeviceName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "DeviceName", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "DeviceName");
        }
    }
}
