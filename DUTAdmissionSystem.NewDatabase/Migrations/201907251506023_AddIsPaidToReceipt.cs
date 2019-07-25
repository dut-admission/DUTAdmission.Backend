namespace DUTAdmissionSystem.NewDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsPaidToReceipt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipts", "IsPaid", c => c.Boolean(nullable: false));
            DropColumn("dbo.Receipts", "ReceiptNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Receipts", "ReceiptNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Receipts", "IsPaid");
        }
    }
}
