namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _26 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankBox",
                c => new
                {
                    IdBankBox = c.Int(nullable: false, identity: true),
                    PricePerMonth = c.Decimal(nullable: false, precision: 18, scale: 2),
                    DateStart = c.DateTime(nullable: false),
                    DateEnd = c.DateTime(nullable: false),
                    OverPayOrDebt = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.IdBankBox);

        }

        public override void Down()
        {
            DropTable("dbo.BankBox");
        }
    }
}
