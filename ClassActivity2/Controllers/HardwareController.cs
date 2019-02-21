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
            vm.Employees = GetEmployees(0);

            //Default Values
            vm.DateFrom = new DateTime(2019, 1, 1);
            vm.DateTo = new DateTime(2019, 1, 31);

            return View(vm);
        }

        private SelectList GetEmployees(int selected)
        {
            using (HardwareDBEntities db = new HardwareDBEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;

                var employees = db.lgemployees.Select(t => new SelectListItem
                {
                    Value = t.emp_num.ToString(),
                    Text = t.emp_fname
                }).ToList();

                if (selected == 0)
                    return new SelectList(employees, "Value", "Text");
                else
                    return new SelectList(employees, "Value", "Text", selected);
            }
        }

        [HttpPost]
        public ActionResult DoReport(HardwareVM vm)
        {
            using (HardwareDBEntities db = new HardwareDBEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                vm.Employees = GetEmployees(vm.SelectedEmployeeID);
                vm.employee = db.lgemployees.Where(x => x.emp_num == vm.SelectedEmployeeID).FirstOrDefault();

                var list = db.lginvoices.Where(r => r.employee_id == vm.employee.emp_num && r.inv_DATETIME >= vm.DateFrom && r.inv_DATETIME <= vm.DateTo).ToList().Select(p => new ReportRecord
                {
                    //OrderDate = p.inv_DATETIME.ToString("dd-MMM-yyyy"),
                    Total = Convert.ToDouble(p.inv_total),
                    Employee = db.lgemployees.Where(r => r.emp_num == p.employee_id).Select(x => x.emp_fname + "" + x.emp_lname).FirstOrDefault(),
                });
            }
            //vm.chartData = list.GroupBy(g => g.Employee).ToDictionary(g => g.Key, g => g.Sum(v => v.Total));
            TempData["chartData"] = vm.chartData;
            //TempData["records"] = list.ToList();
            TempData["vendor"] = vm.employee;

            return View(vm);
        }

        public ActionResult EmployeeSalesChart()
        {
            var data = TempData["chartData"];
            return View(TempData["chartData"]);
        }
    }
}