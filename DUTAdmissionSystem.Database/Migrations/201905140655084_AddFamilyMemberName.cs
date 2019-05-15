namespace DUTAdmissionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFamilyMemberName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FamilyMember", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FamilyMember", "Name");
        }
    }
}
