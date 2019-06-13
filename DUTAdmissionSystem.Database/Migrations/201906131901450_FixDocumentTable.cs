namespace DUTAdmissionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDocumentTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Document", "ResponseMessage", c => c.String());
            AlterColumn("dbo.Document", "Url", c => c.String());
            AlterColumn("dbo.Document", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Document", "FileName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Document", "Url", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Document", "ResponseMessage", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
