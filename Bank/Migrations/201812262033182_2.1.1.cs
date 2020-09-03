namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _211 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Credits", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Credits", "ApplicationUserId");
            AddForeignKey("dbo.Credits", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Credits", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Credits", new[] { "ApplicationUserId" });
            DropColumn("dbo.Credits", "ApplicationUserId");
        }
    }
}
