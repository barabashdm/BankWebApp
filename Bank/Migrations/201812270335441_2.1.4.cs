namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _214 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Comment", c => c.String());
            AddColumn("dbo.Transactions", "PhoneNumber", c => c.String());
            AddColumn("dbo.Transactions", "Surname", c => c.String());
            AddColumn("dbo.Transactions", "Name", c => c.String());
            AddColumn("dbo.Transactions", "Patronymic", c => c.String());
            AddColumn("dbo.Transactions", "CardNumber2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "CardNumber2");
            DropColumn("dbo.Transactions", "Patronymic");
            DropColumn("dbo.Transactions", "Name");
            DropColumn("dbo.Transactions", "Surname");
            DropColumn("dbo.Transactions", "PhoneNumber");
            DropColumn("dbo.Transactions", "Comment");
        }
    }
}
