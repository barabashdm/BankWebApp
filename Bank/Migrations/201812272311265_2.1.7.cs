namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _217 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Currency", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Currency");
        }
    }
}
