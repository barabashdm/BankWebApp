namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankBox", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BankBox", "ApplicationUserId");
            AddForeignKey("dbo.BankBox", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.BankBox", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.BankBox", new[] { "ApplicationUserId" });
            DropColumn("dbo.BankBox", "ApplicationUserId");
        }
    }
}
