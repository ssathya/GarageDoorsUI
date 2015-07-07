namespace ArduinoControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SyncUp0707 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        DataSourceUrl = c.String(maxLength: 255),
                        FreqToPoll = c.Int(nullable: false),
                        ExpectedReportingFreq = c.Int(nullable: false),
                        DurationToIgnore = c.Int(nullable: false),
                        AddressToNotifyIfNoResponse = c.String(maxLength: 100),
                        MinutesBetweenNotification = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InputPorts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 20),
                        MultiplicationFactor = c.Single(nullable: false),
                        NominalLowValue = c.Single(nullable: false),
                        NominalHighValue = c.Single(nullable: false),
                        AlarmLow = c.Single(nullable: false),
                        AlaarmHigh = c.Single(nullable: false),
                        AlarmNotificationAddress = c.String(maxLength: 4000),
                        MinutesBetweenNotification = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.OutputPorts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Unit = c.String(maxLength: 20),
                        MultiplicationFactor = c.Single(nullable: false),
                        CommandIssueTime = c.DateTime(nullable: false),
                        DeviceAckTime = c.DateTime(nullable: false),
                        PulseOrState = c.Boolean(nullable: false),
                        PulseDuration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .Index(t => t.DeviceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OutputPorts", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.InputPorts", "DeviceId", "dbo.Devices");
            DropIndex("dbo.OutputPorts", new[] { "DeviceId" });
            DropIndex("dbo.InputPorts", new[] { "DeviceId" });
            DropTable("dbo.OutputPorts");
            DropTable("dbo.InputPorts");
            DropTable("dbo.Devices");
        }
    }
}
