namespace ArduinoControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedEventValuesFromOutputPort : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OutputPorts", "CommandIssueTime");
            DropColumn("dbo.OutputPorts", "DeviceAckTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OutputPorts", "DeviceAckTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.OutputPorts", "CommandIssueTime", c => c.DateTime(nullable: false));
        }
    }
}
