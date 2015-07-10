namespace ArduinoControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFeedName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InputPorts", "FeedName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.OutputPorts", "FeedName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.InputPorts", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.OutputPorts", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OutputPorts", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.InputPorts", "Name", c => c.String(maxLength: 50));
            DropColumn("dbo.OutputPorts", "FeedName");
            DropColumn("dbo.InputPorts", "FeedName");
        }
    }
}
