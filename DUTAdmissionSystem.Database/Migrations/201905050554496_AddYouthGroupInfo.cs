namespace DUTAdmissionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYouthGroupInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.YouthGroupInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfJoiningYouthGroup = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlaceOfJoinYouthGroup = c.String(maxLength: 255),
                        HavingBooksOfYouthGroup = c.Boolean(nullable: false),
                        HavingCardsOfYouthGroup = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Student", "YouthGroupInfoId", c => c.Int());
            CreateIndex("dbo.Student", "YouthGroupInfoId");
            AddForeignKey("dbo.Student", "YouthGroupInfoId", "dbo.YouthGroupInfo", "Id");
            DropColumn("dbo.Student", "DateOfJoiningYouthGroup");
            DropColumn("dbo.Student", "PlaceOfJoinYouthGroup");
            DropColumn("dbo.Student", "HavingBooksOfYouthGroup");
            DropColumn("dbo.Student", "HavingCardsOfYouthGroup");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "HavingCardsOfYouthGroup", c => c.Boolean(nullable: false));
            AddColumn("dbo.Student", "HavingBooksOfYouthGroup", c => c.Boolean(nullable: false));
            AddColumn("dbo.Student", "PlaceOfJoinYouthGroup", c => c.String(maxLength: 255));
            AddColumn("dbo.Student", "DateOfJoiningYouthGroup", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
            DropForeignKey("dbo.Student", "YouthGroupInfoId", "dbo.YouthGroupInfo");
            DropIndex("dbo.Student", new[] { "YouthGroupInfoId" });
            DropColumn("dbo.Student", "YouthGroupInfoId");
            DropTable("dbo.YouthGroupInfo");
        }
    }
}
