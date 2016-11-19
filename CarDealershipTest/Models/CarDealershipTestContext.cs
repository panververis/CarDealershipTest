using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarDealershipTest.Models
{
    public class CarDealershipTestContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CarDealershipTestContext() : base("name=CarDealershipTestContext")
        {
        }

        public System.Data.Entity.DbSet<CarDealershipTest.Models.Area> Areas { get; set; }

        public System.Data.Entity.DbSet<CarDealershipTest.Models.Dealer> Dealers { get; set; }

        public System.Data.Entity.DbSet<CarDealershipTest.Models.Region> Regions { get; set; }

        public System.Data.Entity.DbSet<CarDealershipTest.Models.Sale> Sales { get; set; }

        public System.Data.Entity.DbSet<CarDealershipTest.Models.Vehicle> Vehicles { get; set; }

        public System.Data.Entity.DbSet<CarDealershipTest.Models.Staff> Staffs { get; set; }
    }
}
