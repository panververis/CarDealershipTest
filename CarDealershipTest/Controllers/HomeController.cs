using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealershipTest.Resources;

namespace CarDealershipTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = Resource.sCarDealershipDashboard;

            return View();
        }
    }
}
