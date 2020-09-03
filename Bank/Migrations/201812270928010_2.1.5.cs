namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _215 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Credits", "CardID");
            AddForeignKey("dbo.Credits", "CardID", "dbo.BankCards", "CardId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Credits", "CardID", "dbo.BankCards");
            DropIndex("dbo.Credits", new[] { "CardID" });
        }
    }
}
