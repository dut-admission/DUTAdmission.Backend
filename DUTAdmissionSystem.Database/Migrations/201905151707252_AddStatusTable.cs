namespace DUTAdmissionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InsuranceDuration", newName: "StatusType");
            DropForeignKey("dbo.InsuranceType", "DurationId", "dbo.InsuranceDuration");
            DropIndex("dbo.InsuranceType", new[] { "DurationId" });
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        StatusTypeId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StatusType", t => t.StatusTypeId)
                .Index(t => t.StatusTypeId);
            
            AddColumn("dbo.Document", "StatusId", c => c.Int(nullable: false));
            AddColumn("dbo.Document", "IsRequired", c => c.Boolean(nullable: false));
            AddColumn("dbo.InsuranceType", "Fees", c => c.Double(nullable: false));
            CreateIndex("dbo.Document", "StatusId");
            AddForeignKey("dbo.Document", "StatusId", "dbo.Status", "Id");
            DropColumn("dbo.Document", "IsValid");
            DropColumn("dbo.InsuranceType", "DurationId");
            DropColumn("dbo.StatusType", "Fees");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StatusType", "Fees", c => c.Double(nullable: false));
            AddColumn("dbo.InsuranceType", "DurationId", c => c.Int(nullable: false));
            AddColumn("dbo.Document", "IsValid", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Status", "StatusTypeId", "dbo.StatusType");
            DropForeignKey("dbo.Document", "StatusId", "dbo.Status");
            DropIndex("dbo.Status", new[] { "StatusTypeId" });
            DropIndex("dbo.Document", new[] { "StatusId" });
            DropColumn("dbo.InsuranceType", "Fees");
            DropColumn("dbo.Document", "IsRequired");
            DropColumn("dbo.Document", "StatusId");
            DropTable("dbo.Status");
            CreateIndex("dbo.InsuranceType", "DurationId");
            AddForeignKey("dbo.InsuranceType", "DurationId", "dbo.InsuranceDuration", "Id");
            RenameTable(name: "dbo.StatusType", newName: "InsuranceDuration");
        }
    }
}
