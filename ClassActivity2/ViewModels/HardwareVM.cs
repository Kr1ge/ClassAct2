using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassActivity2.Models;
//using ClassActivity2.Reports;
using System.Web.Mvc;

namespace ClassActivity2.ViewModels
{
    public class HardwareVM
    {
        public IEnumerable<SelectListItem> Vendors { get; set; }
        public int SelectedVendorID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public lgvendor vendor { get; set; }
        public List<IGrouping<string,ReportRecord>> results { get; set; }
        public Dictionary<string, double> chartData { get; set; }
    }

    public class ReportRecord
    {
        public string OrderDate { get; set; }
        public double Total { get; set; }
        public string Employee { get; set; }
        public int VendorID { get; set; }

    }
}