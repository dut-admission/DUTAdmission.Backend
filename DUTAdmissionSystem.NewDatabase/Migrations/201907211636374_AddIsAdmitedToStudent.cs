namespace DUTAdmissionSystem.NewDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsAdmitedToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "IsJoinYouthGroup", c => c.Boolean(nullable: false));
            AddColumn("dbo.Student", "IsAdmitted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Student", "IsPaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "IsPaid");
            DropColumn("dbo.Student", "IsAdmitted");
            DropColumn("dbo.Student", "IsJoinYouthGroup");
        }
    }
}
