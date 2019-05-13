namespace DUTAdmissionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditContactMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactMessage", "Email", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.ContactMessage", "Emai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactMessage", "Emai", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.ContactMessage", "Email");
        }
    }
}
