using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int DealerID { get; set; }
        public virtual Dealer Dealer { get; set; }

        [NotMapped]
        public Int32 NumberOfSales { get; set; }
        [NotMapped]
        public string FullName { get; set; }
    }
}