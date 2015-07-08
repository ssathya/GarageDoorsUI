namespace ArduinoControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedDataTypesForInputPort : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InputPorts", "AlarmNotificationAddress", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InputPorts", "AlarmNotificationAddress", c => c.String(maxLength: 4000));
        }
    }
}
