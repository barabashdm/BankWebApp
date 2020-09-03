namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        CreditID = c.Int(nullable: false, identity: true),
                        CardID = c.Int(nullable: false),
                        Percent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Summ = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Purp = c.String(),
                        IssueDate = c.DateTime(nullable: false),
                        DeadLine = c.DateTime(nullable: false),
                        LeftToPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CreditID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Credits");
        }
    }
}
