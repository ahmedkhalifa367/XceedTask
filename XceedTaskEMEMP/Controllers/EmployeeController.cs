using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XceedTaskEMEMP.Models;
using XceedTaskEMEMP.Models.ViewModel;


namespace XceedTaskEMEMP.Controllers
{
    public class EmployeeController : Controller
    {
        XceedEmpDB db = new XceedEmpDB();
        // GET: Employee
        public ActionResult Index()
        {

            List<Employee> employees = db.Employees.Include("Country").ToList();
            return View(employees);
        }

        //Get Create 
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.btnTitle = ("Create");
            var Countriess = db.Countries.ToList();
            EmployeeViewModel employeeViewModel = new EmployeeViewModel {
                Countries = Countriess,
                Employee = new Employee()
            };
            return View(employeeViewModel);
        }

        [HttpPost]
        public ActionResult Create(Employee Employee)
        {
            if (!ModelState.IsValid)
            {
                var Countriess = db.Countries.ToList();
                EmployeeViewModel employeeViewModel = new EmployeeViewModel
                {
                    Countries = Countriess,
                    Employee = Employee
                };
                return View(employeeViewModel);
            }
            db.Employees.Add(Employee);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.btnTitle = ("Edit");
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var Employee = db.Employees.FirstOrDefault(a => a.empID == id);

            if (Employee == null)
                return HttpNotFound();
            List<Country> Countriess = db.Countries.ToList();
            EmployeeViewModel employeeViewModel = new EmployeeViewModel
            {
                Countries = Countriess,
                Employee = Employee
            };
            return View(employeeViewModel);
        }

        //Post Edit
        [HttpPost]
        public ActionResult Edit(Employee Employee)
        {
            if (!ModelState.IsValid)
            {
                var Countriess = db.Countries.ToList();
                EmployeeViewModel employeeViewModel = new EmployeeViewModel
                {
                    Countries = Countriess,
                    Employee = Employee
                };
                return View(employeeViewModel);
            }

            var oldEmp = db.Employees.FirstOrDefault(a => a.empID == Employee.empID);

            if (oldEmp == null)
                return HttpNotFound();

            oldEmp.empName = Employee.empName;
            oldEmp.phoneNumber = Employee.phoneNumber;
            oldEmp.age = Employee.age;
            oldEmp.CountryID = Employee.CountryID;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult remove(int id)
        {
            if (id == null)          
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var myEmp = db.Employees.Find(id);
            if (myEmp == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            db.Employees.Remove(myEmp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}