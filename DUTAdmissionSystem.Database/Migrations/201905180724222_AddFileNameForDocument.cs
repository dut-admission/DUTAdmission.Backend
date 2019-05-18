namespace DUTAdmissionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileNameForDocument : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Document", "FileName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Document", "FileName");
        }
    }
}
