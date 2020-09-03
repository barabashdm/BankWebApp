namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _216 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Date");
        }
    }
}
