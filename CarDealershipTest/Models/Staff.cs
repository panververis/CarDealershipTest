using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTest.Models
{

    public enum JobType
    {
        SalesRep,
        Accounting,
        Manager
    }

    public class Staff
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public JobType JobType { get; set; }
        public string DealerID { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}