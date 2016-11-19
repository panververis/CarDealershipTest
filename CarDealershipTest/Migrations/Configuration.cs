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
            Area northArea = new Area() { Name = "North Area" };
            Area southArea = new Area() { Name = "South Area" };

            //Creating the initial Regions. There will be four initial Regions
            Region northernRegionA = new Region() { Name = "Northern Region A" };
            Region northernRegionB = new Region() { Name = "Northern Region B" };
            Region southernRegionA = new Region() { Name = "Southern Region A" };
            Region southernRegionB = new Region() { Name = "Southern Region B" };

            //Creating the initial Vehicles. There will be four initial Vehicles
            Vehicle vehicleA = new Vehicle() { Name = "Vehicle A" };
            Vehicle vehicleB = new Vehicle() { Name = "Vehicle B" };
            Vehicle vehicleC = new Vehicle() { Name = "Vehicle C" };
            Vehicle vehicleD = new Vehicle() { Name = "Vehicle D" };

            //Creating the initial Dealers. There will be four initial Dealers, one per Region
            Dealer northernADealer = new Dealer() { Name = "Northern Dealer A", RegionID = northernRegionA.ID };
            Dealer northernBDealer = new Dealer() { Name = "Northern Dealer B", RegionID = northernRegionB.ID };
            Dealer southernADealer = new Dealer() { Name = "Southern Dealer A", RegionID = southernRegionA.ID };
            Dealer southernBDealer = new Dealer() { Name = "Southern Dealer B", RegionID = southernRegionB.ID };

            //Creating the initial Staff Members. There will be sixteen Staff members, 2 salesman + 1 accounting + 1 manager per Dealer
            Staff northernADealerSalesStaff1 = new Staff() { DealerID = northernADealer.ID, FirstName = "Joycelyn", LastName = "Hartsock", JobType = JobType.SalesRep};
            Staff northernADealerSalesStaff2 = new Staff() { DealerID = northernADealer.ID, FirstName = "Domingo", LastName = "Clem", JobType = JobType.SalesRep };
            Staff northernADealerSalesStaff3 = new Staff() { DealerID = northernADealer.ID, FirstName = "Glen", LastName = "Bollig", JobType = JobType.Accounting };
            Staff northernADealerSalesStaff4 = new Staff() { DealerID = northernADealer.ID, FirstName = "Tierra", LastName = "Rosenzweig", JobType = JobType.Manager };

            Staff northernBDealerSalesStaff1 = new Staff() { DealerID = northernBDealer.ID, FirstName = "Sanjuana", LastName = "Disla", JobType = JobType.SalesRep };
            Staff northernBDealerSalesStaff2 = new Staff() { DealerID = northernBDealer.ID, FirstName = "Leland", LastName = "Kono", JobType = JobType.SalesRep };
            Staff northernBDealerSalesStaff3 = new Staff() { DealerID = northernBDealer.ID, FirstName = "Freeman", LastName = "Bagnall", JobType = JobType.Accounting };
            Staff northernBDealerSalesStaff4 = new Staff() { DealerID = northernBDealer.ID, FirstName = "Debbie", LastName = "Murton", JobType = JobType.Manager };

            Staff southernADealerSalesStaff1 = new Staff() { DealerID = southernADealer.ID, FirstName = "Israel", LastName = "Janas", JobType = JobType.SalesRep };
            Staff southernADealerSalesStaff2 = new Staff() { DealerID = southernADealer.ID, FirstName = "Karrie", LastName = "Mccorkle", JobType = JobType.SalesRep };
            Staff southernADealerSalesStaff3 = new Staff() { DealerID = southernADealer.ID, FirstName = "Aliza", LastName = "Pickell", JobType = JobType.Accounting };
            Staff southernADealerSalesStaff4 = new Staff() { DealerID = southernADealer.ID, FirstName = "Venita", LastName = "Sobczak", JobType = JobType.Manager };

            Staff southernBDealerSalesStaff1 = new Staff() { DealerID = southernBDealer.ID, FirstName = "Kacy", LastName = "Nicastro", JobType = JobType.SalesRep };
            Staff southernBDealerSalesStaff2 = new Staff() { DealerID = southernBDealer.ID, FirstName = "Adele", LastName = "Gessner", JobType = JobType.SalesRep };
            Staff southernBDealerSalesStaff3 = new Staff() { DealerID = southernBDealer.ID, FirstName = "Tameka", LastName = "Pawlowicz", JobType = JobType.Accounting };
            Staff southernBDealerSalesStaff4 = new Staff() { DealerID = southernBDealer.ID, FirstName = "Giuseppe", LastName = "Beckmann", JobType = JobType.Manager };

            //Creating the Sales. 2 sales for each Sales Staff member of the northern regions, 1 per Sales Staff member of the Southern A Region, 
            //repeated for "DateTime.Today" and "DateTime.Today+3 days"
            Sale sale1 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today, StaffID = northernADealerSalesStaff1.ID, VehicleID = vehicleA.ID};
            Sale sale2 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today, StaffID = northernADealerSalesStaff1.ID, VehicleID = vehicleB.ID };
            Sale sale3 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today, StaffID = northernADealerSalesStaff2.ID, VehicleID = vehicleA.ID };
            Sale sale4 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today, StaffID = northernADealerSalesStaff2.ID, VehicleID = vehicleB.ID };

            Sale sale5 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernADealerSalesStaff1.ID, VehicleID = vehicleA.ID };
            Sale sale6 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernADealerSalesStaff1.ID, VehicleID = vehicleB.ID };
            Sale sale7 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernADealerSalesStaff2.ID, VehicleID = vehicleA.ID };
            Sale sale8 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernADealerSalesStaff2.ID, VehicleID = vehicleB.ID };

            Sale sale9 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today, StaffID = northernBDealerSalesStaff1.ID, VehicleID = vehicleA.ID };
            Sale sale10 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today, StaffID = northernBDealerSalesStaff1.ID, VehicleID = vehicleB.ID };
            Sale sale11 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today, StaffID = northernBDealerSalesStaff2.ID, VehicleID = vehicleA.ID };
            Sale sale12 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today, StaffID = northernBDealerSalesStaff2.ID, VehicleID = vehicleB.ID };

            Sale sale13 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernBDealerSalesStaff1.ID, VehicleID = vehicleA.ID };
            Sale sale14 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernBDealerSalesStaff1.ID, VehicleID = vehicleB.ID };
            Sale sale15 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernBDealerSalesStaff2.ID, VehicleID = vehicleA.ID };
            Sale sale16 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernBDealerSalesStaff2.ID, VehicleID = vehicleB.ID };

            Sale sale17 = new Sale() { DealerID = southernADealer.ID, SaleDate = DateTime.Today, StaffID = southernADealerSalesStaff1.ID, VehicleID = vehicleC.ID };
            Sale sale18 = new Sale() { DealerID = southernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = southernADealerSalesStaff1.ID, VehicleID = vehicleD.ID };

            Sale sale19 = new Sale() { DealerID = southernADealer.ID, SaleDate = DateTime.Today, StaffID = southernADealerSalesStaff2.ID, VehicleID = vehicleC.ID };
            Sale sale20 = new Sale() { DealerID = southernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = southernADealerSalesStaff2.ID, VehicleID = vehicleD.ID };

            #region  Areas Handling

            //upserting the initial Areas
            context.Areas.AddOrUpdate(
                    x => x.ID,
                    northArea,
                    southArea
                );

            #endregion

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
