using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassActivity2.Models;
//using ClassActivity2.Reports;
using System.Data;
//using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using ClassActivity2.ViewModels;

namespace ClassActivity2.Controllers
{
    public class HardwareController : Controller
    {
        // GET: Hardware
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DoReport()
        {
            HardwareVM vm = new HardwareVM();
            vm.Vendors = GetVendors(0);

            //Default Values
            vm.DateFrom = new DateTime(2019, 1, 1);
            vm.DateTo = new DateTime(2019, 1, 31);

            return View(vm);
        }

        private SelectList GetVendors(int selected)
        {
            using (Har)
        }
    }
}