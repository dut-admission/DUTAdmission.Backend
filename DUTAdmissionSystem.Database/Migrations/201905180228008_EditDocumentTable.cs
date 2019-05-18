namespace DUTAdmissionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDocumentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Document", "ResponseMessage", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.DocumentType", "IsRequired", c => c.Boolean(nullable: false));
            AddColumn("dbo.DocumentType", "Description", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.PersonalInfo", "PermanentResidence", c => c.String(maxLength: 255));
            DropColumn("dbo.Document", "Name");
            DropColumn("dbo.Document", "IsRequired");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Document", "IsRequired", c => c.Boolean(nullable: false));
            AddColumn("dbo.Document", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.PersonalInfo", "PermanentResidence", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.DocumentType", "Description");
            DropColumn("dbo.DocumentType", "IsRequired");
            DropColumn("dbo.Document", "ResponseMessage");
        }
    }
}
