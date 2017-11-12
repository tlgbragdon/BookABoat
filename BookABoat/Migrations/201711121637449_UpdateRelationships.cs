namespace BookABoat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRelationships : DbMigration
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
                        Rower_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rowers", t => t.Rower_Id)
                .Index(t => t.Rower_Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        BoatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boats", t => t.BoatId, cascadeDelete: true)
                .Index(t => t.BoatId);
            
            CreateTable(
                "dbo.Rowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        EmailAddress = c.String(nullable: false, maxLength: 50),
                        MobilePhone = c.String(),
                        ApprovedSkillLevel = c.Int(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        ValidUntil = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.Reservations", "BoatId", "dbo.Boats");
            DropForeignKey("dbo.RowerReservations", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.RowerReservations", "Rower_Id", "dbo.Rowers");
            DropForeignKey("dbo.Boats", "Rower_Id", "dbo.Rowers");
            DropIndex("dbo.RowerReservations", new[] { "Reservation_Id" });
            DropIndex("dbo.RowerReservations", new[] { "Rower_Id" });
            DropIndex("dbo.Reservations", new[] { "BoatId" });
            DropIndex("dbo.Boats", new[] { "Rower_Id" });
            DropTable("dbo.RowerReservations");
            DropTable("dbo.Rowers");
            DropTable("dbo.Reservations");
            DropTable("dbo.Boats");
        }
    }
}
