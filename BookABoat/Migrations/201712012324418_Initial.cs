namespace BookABoat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        WeightClass = c.Int(nullable: false),
                        MinSkillLevelRequired = c.Int(nullable: false),
                        DateAquired = c.DateTime(nullable: false),
                        Make = c.String(),
                        YearOfManufacture = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        BoatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MobilePhone = c.String(),
                        ApprovedSkillLevel = c.Int(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        ValidUntil = c.DateTime(nullable: false),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReservationBoats",
                c => new
                    {
                        Reservation_Id = c.Int(nullable: false),
                        Boat_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reservation_Id, t.Boat_Id })
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Boats", t => t.Boat_Id, cascadeDelete: true)
                .Index(t => t.Reservation_Id)
                .Index(t => t.Boat_Id);
            
            CreateTable(
                "dbo.RowerReservations",
                c => new
                    {
                        Rower_Id = c.Int(nullable: false),
                        Reservation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rower_Id, t.Reservation_Id })
                .ForeignKey("dbo.Rowers", t => t.Rower_Id, cascadeDelete: true)
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id, cascadeDelete: true)
                .Index(t => t.Rower_Id)
                .Index(t => t.Reservation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RowerReservations", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.RowerReservations", "Rower_Id", "dbo.Rowers");
            DropForeignKey("dbo.ReservationBoats", "Boat_Id", "dbo.Boats");
            DropForeignKey("dbo.ReservationBoats", "Reservation_Id", "dbo.Reservations");
            DropIndex("dbo.RowerReservations", new[] { "Reservation_Id" });
            DropIndex("dbo.RowerReservations", new[] { "Rower_Id" });
            DropIndex("dbo.ReservationBoats", new[] { "Boat_Id" });
            DropIndex("dbo.ReservationBoats", new[] { "Reservation_Id" });
            DropTable("dbo.RowerReservations");
            DropTable("dbo.ReservationBoats");
            DropTable("dbo.Rowers");
            DropTable("dbo.Reservations");
            DropTable("dbo.Boats");
        }
    }
}
