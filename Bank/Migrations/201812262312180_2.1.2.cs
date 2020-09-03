namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _212 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "CardId", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "TransactionType", c => c.String());
            CreateIndex("dbo.Transactions", "CardId");
            AddForeignKey("dbo.Transactions", "CardId", "dbo.BankCards", "CardId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CardId", "dbo.BankCards");
            DropIndex("dbo.Transactions", new[] { "CardId" });
            DropColumn("dbo.Transactions", "TransactionType");
            DropColumn("dbo.Transactions", "CardId");
        }
    }
}
