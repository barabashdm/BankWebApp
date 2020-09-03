namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _218 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bookings", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Hotels", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.Cities", "CountryID", "dbo.Countries");
            DropIndex("dbo.Bookings", new[] { "ApplicationUserId" });
            DropIndex("dbo.Bookings", new[] { "RoomId" });
            DropIndex("dbo.Rooms", new[] { "HotelId" });
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            DropIndex("dbo.Hotels", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "CountryID" });
            DropTable("dbo.Bookings");
            DropTable("dbo.Rooms");
            DropTable("dbo.Hotels");
            DropTable("dbo.Cities");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Countries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        RoomTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelId = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.HotelId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        HotelId = c.Int(nullable: false),
                        RoomTypeId = c.Int(nullable: false),
                        RoomNum = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        NumOfPlaces = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        RoomId = c.Int(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        NumOfPersons = c.Int(nullable: false),
                        PriceFor1Day = c.Int(nullable: false),
                        PriceFull = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId);
            
            CreateIndex("dbo.Cities", "CountryID");
            CreateIndex("dbo.Hotels", "CityId");
            CreateIndex("dbo.Rooms", "RoomTypeId");
            CreateIndex("dbo.Rooms", "HotelId");
            CreateIndex("dbo.Bookings", "RoomId");
            CreateIndex("dbo.Bookings", "ApplicationUserId");
            AddForeignKey("dbo.Cities", "CountryID", "dbo.Countries", "CountryId", cascadeDelete: true);
            AddForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes", "RoomTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels", "HotelId", cascadeDelete: true);
            AddForeignKey("dbo.Hotels", "CityId", "dbo.Cities", "CityId", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
