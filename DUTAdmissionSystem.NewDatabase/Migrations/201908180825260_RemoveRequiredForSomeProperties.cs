namespace DUTAdmissionSystem.NewDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredForSomeProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfo", "PlaceOfBirth", c => c.String(maxLength: 255));
            AlterColumn("dbo.UserInfo", "Email", c => c.String(maxLength: 255));
            AlterColumn("dbo.UserInfo", "Address", c => c.String(maxLength: 255));
            AlterColumn("dbo.Student", "HighSchoolName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "HighSchoolName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.UserInfo", "Address", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.UserInfo", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.UserInfo", "PlaceOfBirth", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
