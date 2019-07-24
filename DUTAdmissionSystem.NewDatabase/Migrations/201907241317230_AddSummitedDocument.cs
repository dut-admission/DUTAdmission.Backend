namespace DUTAdmissionSystem.NewDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSummitedDocument : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Document", "IsSubmitted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Document", "IsSubmitted");
        }
    }
}
