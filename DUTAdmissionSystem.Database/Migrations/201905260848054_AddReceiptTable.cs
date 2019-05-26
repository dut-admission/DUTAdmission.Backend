namespace DUTAdmissionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReceiptTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CollectorUserId = c.Int(nullable: false),
                        PayerUserId = c.Int(nullable: false),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceiptNumber = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        CollectionDate = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfo", t => t.CollectorUserId)
                .ForeignKey("dbo.UserInfo", t => t.PayerUserId)
                .Index(t => t.CollectorUserId)
                .Index(t => t.PayerUserId);
            
            AddColumn("dbo.FunctionInScreen", "IsToViewIndex", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipts", "PayerUserId", "dbo.UserInfo");
            DropForeignKey("dbo.Receipts", "CollectorUserId", "dbo.UserInfo");
            DropIndex("dbo.Receipts", new[] { "PayerUserId" });
            DropIndex("dbo.Receipts", new[] { "CollectorUserId" });
            DropColumn("dbo.FunctionInScreen", "IsToViewIndex");
            DropTable("dbo.Receipts");
        }
    }
}
