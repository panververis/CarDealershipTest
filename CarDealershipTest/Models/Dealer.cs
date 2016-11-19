using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTest.Models
{
    public class Dealer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int RegionID { get; set; }
        public virtual Region Region { get; set; }
        public virtual List<Staff> StaffMembers { get; set; }
        public virtual List<Sale> Sales { get; set; }
    }
}