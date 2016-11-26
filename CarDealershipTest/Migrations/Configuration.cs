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

            //declaring all the to-be-saved Entities
            Area northArea, southArea;
            Region northernRegionA, northernRegionB, southernRegionA, southernRegionB;
            Vehicle vehicleA, vehicleB, vehicleC, vehicleD;
            Dealer northernADealer, northernBDealer, southernADealer, southernBDealer;
            Staff northernADealerSalesStaff1, northernADealerSalesStaff2, northernADealerSalesStaff3, northernADealerSalesStaff4,
            northernBDealerSalesStaff1, northernBDealerSalesStaff2, northernBDealerSalesStaff3, northernBDealerSalesStaff4, southernADealerSalesStaff1,
            southernADealerSalesStaff2, southernADealerSalesStaff3, southernADealerSalesStaff4, southernBDealerSalesStaff1, southernBDealerSalesStaff2,
            southernBDealerSalesStaff3, southernBDealerSalesStaff4;
            Sale sale1, sale2, sale3, sale4, sale5, sale6, sale7, sale8, sale9, sale10, sale11, sale12, sale13,
            sale14, sale15, sale16, sale17, sale18, sale19, sale20;

            #region Defining the total of the data

            #region Areas handling

            #region Areas Initialization

            //Creating the initial Areas. There will be two initial Areas
            northArea = new Area() { Name = "North Area", ID = 1 };
            southArea = new Area() { Name = "South Area", ID = 2 };

            #endregion

            #region Areas "Upsert" operations

            context.Areas.AddOrUpdate(
                    x => x.ID,
                    northArea,
                    southArea
                );

            #endregion

            //posting the changes to the DB
            context.SaveChanges();

            #region Retrieving the posted Areas (along with their updated IDs)

            northArea = context.Areas.FirstOrDefault(x => x.Name == northArea.Name);
            southArea = context.Areas.FirstOrDefault(x => x.Name == southArea.Name);

            #endregion

            #region

            #endregion

            #endregion

            #region Regions handling

            #region Regions Initialization

            //Creating the initial Regions. There will be four initial Regions
            northernRegionA = new Region() { Name = "Northern Region A", ID = 1, AreaID = northArea.ID};
            northernRegionB = new Region() { Name = "Northern Region B", ID = 2, AreaID = northArea.ID };
            southernRegionA = new Region() { Name = "Southern Region A", ID = 3, AreaID = southArea.ID };
            southernRegionB = new Region() { Name = "Southern Region B", ID = 4, AreaID = southArea.ID };

            #endregion

            #region Regions "Upsert" Operations

            context.Regions.AddOrUpdate(
                    x => x.ID,
                    northernRegionA,
                    northernRegionB,
                    southernRegionA,
                    southernRegionB
                );

            #endregion

            //posting the changes to the DB
            context.SaveChanges();

            #region Retrieving the posted Regions (along with their updated IDs)

            northernRegionA = context.Regions.FirstOrDefault(x => x.Name == northernRegionA.Name);
            northernRegionB = context.Regions.FirstOrDefault(x => x.Name == northernRegionB.Name);
            southernRegionA = context.Regions.FirstOrDefault(x => x.Name == southernRegionA.Name);
            southernRegionB = context.Regions.FirstOrDefault(x => x.Name == southernRegionB.Name);

            #endregion

            #endregion

            #region Vehicles handling

            #region Vehicles Initialization

            //Creating the initial Vehicles. There will be four initial Vehicles
            vehicleA = new Vehicle() { Name = "Vehicle A", ID = 1 };
            vehicleB = new Vehicle() { Name = "Vehicle B", ID = 2 };
            vehicleC = new Vehicle() { Name = "Vehicle C", ID = 3 };
            vehicleD = new Vehicle() { Name = "Vehicle D", ID = 4 };

            #endregion

            #region Vehicles "Upsert" Operations

            context.Vehicles.AddOrUpdate(
                    x => x.ID,
                    vehicleA,
                    vehicleB,
                    vehicleC,
                    vehicleD
                );

            #endregion

            //posting the changes to the DB
            context.SaveChanges();

            #region Retrieving the posted Vehicles (along with their updated IDs)

            vehicleA = context.Vehicles.FirstOrDefault(x => x.Name == vehicleA.Name);
            vehicleB = context.Vehicles.FirstOrDefault(x => x.Name == vehicleB.Name);
            vehicleC = context.Vehicles.FirstOrDefault(x => x.Name == vehicleC.Name);
            vehicleD = context.Vehicles.FirstOrDefault(x => x.Name == vehicleD.Name);

            #endregion

            #endregion

            #region Dealers handling

            #region Dealers Initialization

            //Creating the initial Dealers. There will be four initial Dealers, one per Region
            northernADealer = new Dealer() { Name = "Northern Dealer A", RegionID = northernRegionA.ID, ID = 1 };
            northernBDealer = new Dealer() { Name = "Northern Dealer B", RegionID = northernRegionB.ID, ID = 2 };
            southernADealer = new Dealer() { Name = "Southern Dealer A", RegionID = southernRegionA.ID, ID = 3 };
            southernBDealer = new Dealer() { Name = "Southern Dealer B", RegionID = southernRegionB.ID, ID = 4 };

            #endregion

            #region Regions "Upsert" Operations

            context.Dealers.AddOrUpdate(
                    x => x.ID,
                    northernADealer,
                    northernBDealer,
                    southernADealer,
                    southernBDealer
                );

            #endregion

            //posting the changes to the DB
            context.SaveChanges();

            #region Retrieving the posted Dealers (along with their updated IDs)

            northernADealer = context.Dealers.FirstOrDefault(x => x.Name == northernADealer.Name);
            northernBDealer = context.Dealers.FirstOrDefault(x => x.Name == northernBDealer.Name);
            southernADealer = context.Dealers.FirstOrDefault(x => x.Name == southernADealer.Name);
            southernBDealer = context.Dealers.FirstOrDefault(x => x.Name == southernBDealer.Name);

            #endregion

            #endregion

            #region Staff handling

            #region Staff Initialization

            //Creating the initial Staff Members. There will be sixteen Staff members, 2 salesmen + 1 accounting + 1 manager per Dealer
            northernADealerSalesStaff1 = new Staff() { DealerID = northernADealer.ID, FirstName = "Joycelyn", LastName = "Hartsock", JobType = JobType.SalesRep, ID = 1 };
            northernADealerSalesStaff2 = new Staff() { DealerID = northernADealer.ID, FirstName = "Domingo", LastName = "Clem", JobType = JobType.SalesRep, ID = 2 };
            northernADealerSalesStaff3 = new Staff() { DealerID = northernADealer.ID, FirstName = "Glen", LastName = "Bollig", JobType = JobType.Accounting, ID = 3 };
            northernADealerSalesStaff4 = new Staff() { DealerID = northernADealer.ID, FirstName = "Tierra", LastName = "Rosenzweig", JobType = JobType.Manager, ID = 4 };
            northernBDealerSalesStaff1 = new Staff() { DealerID = northernBDealer.ID, FirstName = "Sanjuana", LastName = "Disla", JobType = JobType.SalesRep, ID = 5 };
            northernBDealerSalesStaff2 = new Staff() { DealerID = northernBDealer.ID, FirstName = "Leland", LastName = "Kono", JobType = JobType.SalesRep, ID = 6 };
            northernBDealerSalesStaff3 = new Staff() { DealerID = northernBDealer.ID, FirstName = "Freeman", LastName = "Bagnall", JobType = JobType.Accounting, ID = 7 };
            northernBDealerSalesStaff4 = new Staff() { DealerID = northernBDealer.ID, FirstName = "Debbie", LastName = "Murton", JobType = JobType.Manager, ID = 8 };
            southernADealerSalesStaff1 = new Staff() { DealerID = southernADealer.ID, FirstName = "Israel", LastName = "Janas", JobType = JobType.SalesRep, ID = 9 };
            southernADealerSalesStaff2 = new Staff() { DealerID = southernADealer.ID, FirstName = "Karrie", LastName = "Mccorkle", JobType = JobType.SalesRep, ID = 10 };
            southernADealerSalesStaff3 = new Staff() { DealerID = southernADealer.ID, FirstName = "Aliza", LastName = "Pickell", JobType = JobType.Accounting, ID = 11 };
            southernADealerSalesStaff4 = new Staff() { DealerID = southernADealer.ID, FirstName = "Venita", LastName = "Sobczak", JobType = JobType.Manager, ID = 12 };
            southernBDealerSalesStaff1 = new Staff() { DealerID = southernBDealer.ID, FirstName = "Kacy", LastName = "Nicastro", JobType = JobType.SalesRep, ID = 13 };
            southernBDealerSalesStaff2 = new Staff() { DealerID = southernBDealer.ID, FirstName = "Adele", LastName = "Gessner", JobType = JobType.SalesRep, ID = 14 };
            southernBDealerSalesStaff3 = new Staff() { DealerID = southernBDealer.ID, FirstName = "Tameka", LastName = "Pawlowicz", JobType = JobType.Accounting, ID = 15 };
            southernBDealerSalesStaff4 = new Staff() { DealerID = southernBDealer.ID, FirstName = "Giuseppe", LastName = "Beckmann", JobType = JobType.Manager, ID = 16 };

            #endregion

            #region Staff "Upsert" Operations

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

            //posting the changes to the DB
            context.SaveChanges();

            #region Retrieving the posted Staff (along with their updated IDs)

            northernADealerSalesStaff1 = context.Staffs.FirstOrDefault(x => x.FirstName == northernADealerSalesStaff1.FirstName && x.LastName == northernADealerSalesStaff1.LastName);
            northernADealerSalesStaff2 = context.Staffs.FirstOrDefault(x => x.FirstName == northernADealerSalesStaff2.FirstName && x.LastName == northernADealerSalesStaff2.LastName);
            northernADealerSalesStaff3 = context.Staffs.FirstOrDefault(x => x.FirstName == northernADealerSalesStaff3.FirstName && x.LastName == northernADealerSalesStaff3.LastName);
            northernADealerSalesStaff4 = context.Staffs.FirstOrDefault(x => x.FirstName == northernADealerSalesStaff4.FirstName && x.LastName == northernADealerSalesStaff4.LastName);
            northernBDealerSalesStaff1 = context.Staffs.FirstOrDefault(x => x.FirstName == northernBDealerSalesStaff1.FirstName && x.LastName == northernBDealerSalesStaff1.LastName);
            northernBDealerSalesStaff2 = context.Staffs.FirstOrDefault(x => x.FirstName == northernBDealerSalesStaff2.FirstName && x.LastName == northernBDealerSalesStaff2.LastName);
            northernBDealerSalesStaff3 = context.Staffs.FirstOrDefault(x => x.FirstName == northernBDealerSalesStaff3.FirstName && x.LastName == northernBDealerSalesStaff3.LastName);
            southernADealerSalesStaff1 = context.Staffs.FirstOrDefault(x => x.FirstName == southernADealerSalesStaff1.FirstName && x.LastName == southernADealerSalesStaff1.LastName);
            southernADealerSalesStaff2 = context.Staffs.FirstOrDefault(x => x.FirstName == southernADealerSalesStaff2.FirstName && x.LastName == southernADealerSalesStaff2.LastName);
            southernADealerSalesStaff3 = context.Staffs.FirstOrDefault(x => x.FirstName == southernADealerSalesStaff3.FirstName && x.LastName == southernADealerSalesStaff3.LastName);
            southernADealerSalesStaff4 = context.Staffs.FirstOrDefault(x => x.FirstName == southernADealerSalesStaff4.FirstName && x.LastName == southernADealerSalesStaff4.LastName);
            southernBDealerSalesStaff1 = context.Staffs.FirstOrDefault(x => x.FirstName == southernBDealerSalesStaff1.FirstName && x.LastName == southernBDealerSalesStaff1.LastName);
            southernBDealerSalesStaff2 = context.Staffs.FirstOrDefault(x => x.FirstName == southernBDealerSalesStaff2.FirstName && x.LastName == southernBDealerSalesStaff2.LastName);
            southernBDealerSalesStaff3 = context.Staffs.FirstOrDefault(x => x.FirstName == southernBDealerSalesStaff3.FirstName && x.LastName == southernBDealerSalesStaff3.LastName);
            southernBDealerSalesStaff4 = context.Staffs.FirstOrDefault(x => x.FirstName == southernBDealerSalesStaff4.FirstName && x.LastName == southernBDealerSalesStaff4.LastName);

            #endregion

            #endregion

            #region Sales handling

            #region Sales Initialization

            //Creating the Sales. 2 sales for each Sales Staff member of the northern regions, 1 per Sales Staff member of the Southern A Region, 
            //repeated for "DateTime.Today" and "DateTime.Today+3 days"
            sale1 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today, StaffID = northernADealerSalesStaff1.ID, VehicleID = vehicleA.ID, ID = 1, SaleValue = 100 };
            sale2 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today, StaffID = northernADealerSalesStaff1.ID, VehicleID = vehicleB.ID, ID = 2, SaleValue = 150 };
            sale3 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today, StaffID = northernADealerSalesStaff2.ID, VehicleID = vehicleA.ID, ID = 3, SaleValue = 200 };
            sale4 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today, StaffID = northernADealerSalesStaff2.ID, VehicleID = vehicleB.ID, ID = 4, SaleValue = 180 };
            sale5 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernADealerSalesStaff1.ID, VehicleID = vehicleA.ID, ID = 5, SaleValue = 140 };
            sale6 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernADealerSalesStaff1.ID, VehicleID = vehicleB.ID, ID = 6, SaleValue = 190 };
            sale7 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernADealerSalesStaff2.ID, VehicleID = vehicleA.ID, ID = 7, SaleValue = 170 };
            sale8 = new Sale() { DealerID = northernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernADealerSalesStaff2.ID, VehicleID = vehicleB.ID, ID = 8, SaleValue = 140 };
            sale9 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today, StaffID = northernBDealerSalesStaff1.ID, VehicleID = vehicleA.ID, ID = 9, SaleValue = 156 };
            sale10 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today, StaffID = northernBDealerSalesStaff1.ID, VehicleID = vehicleB.ID, ID = 10, SaleValue = 180 };
            sale11 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today, StaffID = northernBDealerSalesStaff2.ID, VehicleID = vehicleA.ID, ID = 11, SaleValue = 190 };
            sale12 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today, StaffID = northernBDealerSalesStaff2.ID, VehicleID = vehicleB.ID, ID = 12, SaleValue = 140 };
            sale13 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernBDealerSalesStaff1.ID, VehicleID = vehicleA.ID, ID = 13, SaleValue = 130 };
            sale14 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernBDealerSalesStaff1.ID, VehicleID = vehicleB.ID, ID = 14, SaleValue = 120 };
            sale15 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernBDealerSalesStaff2.ID, VehicleID = vehicleA.ID, ID = 15, SaleValue = 190 };
            sale16 = new Sale() { DealerID = northernBDealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = northernBDealerSalesStaff2.ID, VehicleID = vehicleB.ID, ID = 16, SaleValue = 160 };
            sale17 = new Sale() { DealerID = southernADealer.ID, SaleDate = DateTime.Today, StaffID = southernADealerSalesStaff1.ID, VehicleID = vehicleC.ID, ID = 17, SaleValue = 300 };
            sale18 = new Sale() { DealerID = southernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = southernADealerSalesStaff1.ID, VehicleID = vehicleD.ID, ID = 18, SaleValue = 310 };
            sale19 = new Sale() { DealerID = southernADealer.ID, SaleDate = DateTime.Today, StaffID = southernADealerSalesStaff2.ID, VehicleID = vehicleC.ID, ID = 19, SaleValue = 340 };
            sale20 = new Sale() { DealerID = southernADealer.ID, SaleDate = DateTime.Today.AddDays(3), StaffID = southernADealerSalesStaff2.ID, VehicleID = vehicleD.ID, ID = 20, SaleValue = 380 };

            #endregion

            #region Sales "Upsert" Operations

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

            #endregion

            #endregion

        }

    }
}
