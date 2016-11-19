using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTest.Models
{
    public class Region
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AreaID { get; set; }
        public virtual Area Area { get; set; }
    }
}