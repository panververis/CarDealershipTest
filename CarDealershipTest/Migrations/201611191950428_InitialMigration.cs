namespace CarDealershipTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AreaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Areas", t => t.AreaID, cascadeDelete: true)
                .Index(t => t.AreaID);
            
            CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RegionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Regions", t => t.RegionID, cascadeDelete: true)
                .Index(t => t.RegionID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DealerID = c.Int(nullable: false),
                        StaffID = c.Int(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        VehicleID = c.Int(nullable: false),
                        SaleValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Vehicles", t => t.VehicleID, cascadeDelete: true)
                .ForeignKey("dbo.Dealers", t => t.DealerID, cascadeDelete: true)
                .Index(t => t.DealerID)
                .Index(t => t.VehicleID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        JobType = c.Int(nullable: false),
                        DealerID = c.String(),
                        Dealer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dealers", t => t.Dealer_ID)
                .Index(t => t.Dealer_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "Dealer_ID", "dbo.Dealers");
            DropForeignKey("dbo.Sales", "DealerID", "dbo.Dealers");
            DropForeignKey("dbo.Sales", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Dealers", "RegionID", "dbo.Regions");
            DropForeignKey("dbo.Regions", "AreaID", "dbo.Areas");
            DropIndex("dbo.Staffs", new[] { "Dealer_ID" });
            DropIndex("dbo.Sales", new[] { "VehicleID" });
            DropIndex("dbo.Sales", new[] { "DealerID" });
            DropIndex("dbo.Dealers", new[] { "RegionID" });
            DropIndex("dbo.Regions", new[] { "AreaID" });
            DropTable("dbo.Staffs");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Sales");
            DropTable("dbo.Dealers");
            DropTable("dbo.Regions");
            DropTable("dbo.Areas");
        }
    }
}
