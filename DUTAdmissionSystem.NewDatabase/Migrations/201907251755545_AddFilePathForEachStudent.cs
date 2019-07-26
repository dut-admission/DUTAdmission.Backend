namespace DUTAdmissionSystem.NewDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFilePathForEachStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "DocumentFilePath", c => c.String());
            AddColumn("dbo.Student", "ReceiptFilePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "ReceiptFilePath");
            DropColumn("dbo.Student", "DocumentFilePath");
        }
    }
}
