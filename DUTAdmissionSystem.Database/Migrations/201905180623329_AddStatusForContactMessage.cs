namespace DUTAdmissionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusForContactMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactMessage", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContactMessage", "StatusId");
            AddForeignKey("dbo.ContactMessage", "StatusId", "dbo.Status", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactMessage", "StatusId", "dbo.Status");
            DropIndex("dbo.ContactMessage", new[] { "StatusId" });
            DropColumn("dbo.ContactMessage", "StatusId");
        }
    }
}
