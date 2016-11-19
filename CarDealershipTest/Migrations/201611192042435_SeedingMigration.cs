namespace CarDealershipTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Staffs", "Dealer_ID", "dbo.Dealers");
            DropIndex("dbo.Staffs", new[] { "Dealer_ID" });
            DropColumn("dbo.Staffs", "DealerID");
            RenameColumn(table: "dbo.Staffs", name: "Dealer_ID", newName: "DealerID");
            AlterColumn("dbo.Staffs", "DealerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Staffs", "DealerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Staffs", "DealerID");
            AddForeignKey("dbo.Staffs", "DealerID", "dbo.Dealers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "DealerID", "dbo.Dealers");
            DropIndex("dbo.Staffs", new[] { "DealerID" });
            AlterColumn("dbo.Staffs", "DealerID", c => c.Int());
            AlterColumn("dbo.Staffs", "DealerID", c => c.String());
            RenameColumn(table: "dbo.Staffs", name: "DealerID", newName: "Dealer_ID");
            AddColumn("dbo.Staffs", "DealerID", c => c.String());
            CreateIndex("dbo.Staffs", "Dealer_ID");
            AddForeignKey("dbo.Staffs", "Dealer_ID", "dbo.Dealers", "ID");
        }
    }
}
