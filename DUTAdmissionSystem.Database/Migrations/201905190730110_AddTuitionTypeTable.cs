namespace DUTAdmissionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTuitionTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TuitionType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Money = c.Double(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 255),
                        SchoolYear = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AccountGroup", "Description", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountGroup", "Description");
            DropTable("dbo.TuitionType");
        }
    }
}
