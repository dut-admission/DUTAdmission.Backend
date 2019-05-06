namespace DUTAdmissionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringLengthForIdentityNumber : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Confiuration", newName: "Configuration");
            AlterColumn("dbo.IdentityInfo", "IdentityNumber", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IdentityInfo", "IdentityNumber", c => c.String(maxLength: 1));
            RenameTable(name: "dbo.Configuration", newName: "Confiuration");
        }
    }
}
