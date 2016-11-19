using CarDealershipTest.Models;

namespace CarDealershipTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealershipTest.Models.CarDealershipTestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealershipTest.Models.CarDealershipTestContext context)
        {

            //Creating the initial Areas. There will be two initial Areas
            Area northArea = new Area() { Name = "North Area", ID = 1 };
            Area southArea = new Area() { Name = "South Area", ID = 2 };

            #region  Areas Handling

            //upserting the initial Areas
            context.Areas.AddOrUpdate(
                    x => x.ID,
                    northArea,
                    southArea
                );

            #endregion

            //Creating the initial Regions. There will be four initial Regions
            Region northernRegionA = new Region() { Name = "Northern Region A", ID = 1, AreaID = northArea.ID};
            Region northernRegionB = new Region() { Name = "Northern Region B", ID = 2, AreaID = northArea.ID };
            Region southernRegionA = new Region() { Name = "Southern Region A", ID = 3, AreaID = southArea.ID };
            Region southernRegionB = new Region() { Name = "Southern Region B", ID = 4, AreaID = southArea.ID };

            #region Regions handling

            //upserting the initial Regions
            context.Regions.AddOrUpdate(
                    x => x.ID,
                    northernRegionA,
                    northernRegionB,
                    southernRegionA,
                    southernRegionB
                );

            #endregion

            //Creating the initial Vehicles. There will be four initial Vehicles
            Vehicle vehicleA = new Vehicle() { Name = "Vehicle A", ID = 1 };
            Vehicle vehicleB = new Vehicle() { Name = "Vehicle B", ID = 2 };
            Vehicle vehicleC = new Vehicle() { Name = "Vehicle C", ID = 3 };
            Vehicle vehicleD = new Vehicle() { Name = "Vehicle D", ID = 4 };

            #region  Vehicles handling

            //upserting the initial Vehicles
            context.Vehicles.AddOrUpdate(
                    x => x.ID,
                    vehicleA,
                    vehicleB,
                    vehicleC,
                    vehicleD
                );

            #endregion

            //Creating the initial Dealers. There will be four initial Dealers, one per Region
            Dealer northernADealer = new Dealer() { Name = "Northern Dealer A", RegionID = northernRegionA.ID, ID = 1 };
            Dealer northernBDealer = new Dealer() { Name = "Northern Dealer B", RegionID = northernRegionB.ID, ID = 2 };
            Dealer southernADealer = new Dealer() { Name = "Southern Dealer A", RegionID = southernRegionA.ID, ID = 3 };
            Dealer southernBDealer = new Dealer() { Name = "Southern Dealer B", RegionID = southernRegionB.ID, ID = 4 };

            #region  Dealers handling

            //upserting the initial Dealers
            context.Dealers.AddOrUpdate(
                    x => x.ID,
                    northernADealer,
                    northernBDealer,
                    southernADealer,
                    southernBDealer
                );

            #endregion

            //Creating the initial Staff Members. There will be sixteen Staff members, 2 salesman + 1 accounting + 1 manager per Dealer
            Staff northernADealerSalesStaff1 = new Staff() { DealerID = northernADealer.ID, FirstName = "Joycelyn", LastName = "Hartsock", JobType = JobType.SalesRep, ID = 1 };
            Staff northernADealerSalesStaff2 = new Staff() { DealerID = northernADealer.ID, FirstName = "Domingo", LastName = "Clem", JobType = JobType.SalesRep, ID = 2 };
            Staff northernADealerSalesStaff3 = new Staff() { DealerID = northernADealer.ID, FirstName = "Glen", LastName = "Bollig", JobType = JobType.Accounting, ID = 3 };
            Staff northernADealerSalesStaff4 = new Staff() { DealerID = northernADealer.ID, FirstName = "Tierra", LastName = "Rosenzweig", JobType = JobType.Manager, ID = 4 };
            Staff northernBDealerSalesStaff1 = new Staff() { DealerID = northernBDealer.ID, FirstName = "Sanjuana", LastName = "Disla", JobType = JobType.SalesRep, ID = 5 };
            Staff northernBDealerSalesStaff2 = new Staff() { DealerID = northernBDealer.ID, FirstName = "Leland", LastName = "Kono", JobType = JobType.SalesRep, ID = 6 };
            Staff northernBDealerSalesStaff3 = new Staff() { DealerID = northernBDealer.ID, FirstName = "Freeman", LastName = "Bagnall", JobType = JobType.Accounting, ID = 7 };
            Staff northernBDealerSalesStaff4 = new Staff() { DealerID = northernBDealer.ID, FirstName = "Debbie", LastName = "Murton", JobType = JobType.Manager, ID = 8 };
            Staff southernADealerSalesStaff1 = new Staff() { DealerID = southernADealer.ID, FirstName = "Israel", LastName = "Janas", JobType = JobType.SalesRep, ID = 9 };
            Staff southernADealerSalesStaff2 = new Staff() { DealerID = southernADealer.ID, FirstName = "Karrie", LastName = "Mccorkle", JobType = JobType.SalesRep, ID = 10 };
            Staff southernADealerSalesStaff3 = new Staff() { DealerID = southernADealer.ID, FirstName = "Aliza", LastName = "Pickell", JobType = JobType.Accounting, ID = 11 };
            Staff southernADealerSalesStaff4 = new Staff() { DealerID = southernADealer.ID, FirstName = "Venita", LastName = "Sobczak", JobType = JobType.Manager, ID = 12 };
            Staff southernBDealerSalesStaff1 = new Staff() { DealerID = southernBDealer.ID, FirstName = "Kacy", LastName = "Nicastro", JobType = JobType.SalesRep, ID = 13 };
            Staff southernBDealerSalesStaff2 = new Staff() { DealerID = southernBDealer.ID, FirstName = "Adele", LastName = "Gessner", JobType = JobType.SalesRep, ID = 14 };
            Staff southernBDealerSalesStaff3 = new Staff() { DealerID = southernBDealer.ID, FirstName = "Tameka", LastName = "Pawlowicz", JobType = JobType.Accounting, ID = 15 };
            Staff southernBDealerSalesStaff4 = new Staff() { DealerID = southernBDealer.ID, FirstName = "Giuseppe", LastName = "Beckmann", JobType = JobType.Manager, ID = 16 };

            #region Staff Members Handling

            //upserting the initial Staff Members
            context.Staffs.AddOrUpdate(
                    x => x.ID,
                    northernADealerSalesStaff1,
                    northernADealerSalesStaff2,
                    northernADealerSalesStaff3,
                    northernADealerSalesStaff4,
                    northernBDealerSalesStaff1,
                    northernBDealerSalesStaff2,
                    northernBDealerSalesStaff3,
                    northernBDealerSalesStaff4,
                    southernADealerSalesStaff1,
                    southernADealerSalesStaff2,
                    southernADealerSalesStaff3,
                    southernADealerSalesStaff4,
                    southernBDealerSalesStaff1,
                    southernBDealerSalesStaff2,
                    southernBDealerSalesStaff3,
                    southernBDealerSalesStaff4
                );

            #endregion

            //Creating the Sales. 2 sales for each Sales Staff member of the northern regions, 1 per Sales Staff member of the Southern A Region, 
            //repeated for "DateTime.Today" and "DateTime.Today+3 days"
            Sale sale1 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today, StaffID = northernADealerSalesStaff1.ID, VehicleID = vehicleA.ID, ID = 1, SaleValue = 100};
            Sale sale2 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today, StaffID = northernADealerSalesStaff1.ID, VehicleID = vehicleB.ID, ID = 2, SaleValue = 150 };
            Sale sale3 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today, StaffID = northernADealerSalesStaff2.ID, VehicleID = vehicleA.ID, ID = 3, SaleValue = 200 };
            Sale sale4 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today, StaffID = northernADealerSalesStaff2.ID, VehicleID = vehicleB.ID, ID = 4, SaleValue = 180 };
            Sale sale5 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernADealerSalesStaff1.ID, VehicleID = vehicleA.ID, ID = 5, SaleValue = 140 };
            Sale sale6 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernADealerSalesStaff1.ID, VehicleID = vehicleB.ID, ID = 6, SaleValue = 190 };
            Sale sale7 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernADealerSalesStaff2.ID, VehicleID = vehicleA.ID, ID = 7, SaleValue = 170 };
            Sale sale8 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernADealerSalesStaff2.ID, VehicleID = vehicleB.ID, ID = 8, SaleValue = 140 };
            Sale sale9 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today, StaffID = northernBDealerSalesStaff1.ID, VehicleID = vehicleA.ID, ID = 9, SaleValue = 156 };
            Sale sale10 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today, StaffID = northernBDealerSalesStaff1.ID, VehicleID = vehicleB.ID, ID = 10, SaleValue = 180 };
            Sale sale11 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today, StaffID = northernBDealerSalesStaff2.ID, VehicleID = vehicleA.ID, ID = 11, SaleValue = 190 };
            Sale sale12 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today, StaffID = northernBDealerSalesStaff2.ID, VehicleID = vehicleB.ID, ID = 12, SaleValue = 140 };
            Sale sale13 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernBDealerSalesStaff1.ID, VehicleID = vehicleA.ID, ID = 13, SaleValue = 130 };
            Sale sale14 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernBDealerSalesStaff1.ID, VehicleID = vehicleB.ID, ID = 14, SaleValue = 120 };
            Sale sale15 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernBDealerSalesStaff2.ID, VehicleID = vehicleA.ID, ID = 15, SaleValue = 190 };
            Sale sale16 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernBDealerSalesStaff2.ID, VehicleID = vehicleB.ID, ID = 16, SaleValue = 160 };
            Sale sale17 = new Sale() { DealerID = southernADealer.ID, SaleDate = DateTime.Today, StaffID = southernADealerSalesStaff1.ID, VehicleID = vehicleC.ID, ID = 17, SaleValue = 300 };
            Sale sale18 = new Sale() { DealerID = southernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = southernADealerSalesStaff1.ID, VehicleID = vehicleD.ID, ID = 18, SaleValue = 310 };
            Sale sale19 = new Sale() { DealerID = southernADealer.ID, SaleDate = DateTime.Today, StaffID = southernADealerSalesStaff2.ID, VehicleID = vehicleC.ID, ID = 19, SaleValue = 340 };
            Sale sale20 = new Sale() { DealerID = southernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = southernADealerSalesStaff2.ID, VehicleID = vehicleD.ID, ID = 20, SaleValue = 380 };

            #region Sales Handling

            //upserting the initial Sales
            context.Sales.AddOrUpdate(
                    x => x.ID,
                    sale1,
                    sale2,
                    sale3,
                    sale4,
                    sale5,
                    sale6,
                    sale7,
                    sale8,
                    sale9,
                    sale10,
                    sale11,
                    sale12,
                    sale13,
                    sale14,
                    sale15,
                    sale16,
                    sale17,
                    sale18,
                    sale19,
                    sale20
                );

            #endregion

        }

    }
}
