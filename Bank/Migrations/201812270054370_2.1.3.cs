namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _213 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "CardNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "CardNumber");
        }
    }
}
