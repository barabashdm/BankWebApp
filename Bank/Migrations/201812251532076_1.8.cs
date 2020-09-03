namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankCards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        CardNumber = c.String(),
                        ReceivingDate = c.DateTime(nullable: false),
                        ValidUntil = c.DateTime(nullable: false),
                        Currency = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankCards", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.BankCards", new[] { "ApplicationUserId" });
            DropTable("dbo.BankCards");
        }
    }
}
