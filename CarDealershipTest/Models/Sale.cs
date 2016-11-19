using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTest.Models
{
    public class Sale
    {
        public int ID { get; set; }
        public int DealerID { get; set; }
        public int StaffID { get; set; }
        public DateTime SaleDate { get; set; }
        public int VehicleID { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public decimal SaleValue { get; set; }
    }
}