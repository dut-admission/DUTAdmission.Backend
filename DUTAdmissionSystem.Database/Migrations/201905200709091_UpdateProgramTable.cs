namespace DUTAdmissionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProgramTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Class", "ProgramId", "dbo.Program");
            DropIndex("dbo.Class", new[] { "ProgramId" });
            AddColumn("dbo.Department", "DepartmentCode", c => c.String(maxLength: 50));
            AddColumn("dbo.Department", "ProgramId", c => c.Int(nullable: false));
            CreateIndex("dbo.Department", "ProgramId");
            AddForeignKey("dbo.Department", "ProgramId", "dbo.Program", "Id");
            DropColumn("dbo.Class", "ProgramId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Class", "ProgramId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Department", "ProgramId", "dbo.Program");
            DropIndex("dbo.Department", new[] { "ProgramId" });
            DropColumn("dbo.Department", "ProgramId");
            DropColumn("dbo.Department", "DepartmentCode");
            CreateIndex("dbo.Class", "ProgramId");
            AddForeignKey("dbo.Class", "ProgramId", "dbo.Program", "Id");
        }
    }
}
