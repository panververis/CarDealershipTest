using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTest.Models
{
    public class Area
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Region> Regions { get; set; }
    }
}