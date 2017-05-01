using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeMVC.Models;

namespace EmployeeMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeDbContext db = new EmployeeDbContext();

        // GET: Employees
        public ActionResult Index(string SearchBy, string SearchValue, string sortBy)
        {
            var searchTypes = new List<string>();
            searchTypes.Add("Last Name");
            searchTypes.Add("First Name");
            searchTypes.Add("Department");
            searchTypes.Add("Location");
            ViewBag.SearchBy = new SelectList(searchTypes);


            var employees = from e in db.Employees select e;
            if(!String.IsNullOrEmpty(SearchValue) && !String.IsNullOrEmpty(SearchBy))
            {
                if(SearchBy.Equals("Last Name"))
                {
                    employees = employees.Where(e => e.LastName.Contains(SearchValue));
                }
                else if(SearchBy.Equals("First Name"))
                {
                    employees = employees.Where(e => e.FirstName.Contains(SearchValue));
                }
                else if(SearchBy.Equals("Department"))
                {
                    employees = employees.Where(e => e.Department.Contains(SearchValue));
                }
                else if(SearchBy.Equals("Location"))
                {
                    employees = employees.Where(e => e.Location.Contains(SearchValue));
                }
            }

            if(!String.IsNullOrEmpty(sortBy))
            {
                if(sortBy.Equals("LastName"))
                {
                    employees = employees.OrderBy(e => e.LastName);
                }
                else if(sortBy.Equals("FirstName"))
                {
                    employees = employees.OrderBy(e => e.FirstName);
                }
                else if(sortBy.Equals("Department"))
                {
                    employees = employees.OrderBy(e => e.Department);
                }
                else if(sortBy.Equals("Performance"))
                {
                    employees = employees.OrderBy(e => e.Performance);
                }
            }


            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,LastName,FirstName,Salary,Gender,Department,Location,Performance")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,LastName,FirstName,Salary,Gender,Department,Location,Performance")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Select(string employee)
        {
            if(String.IsNullOrEmpty(employee))
            {
                var employees = from e in db.Employees select e;
                var fullNames = from e in employees select new { fullName = e.FirstName + " " + e.LastName, id = e.EmployeeId.ToString() };

                ViewBag.employee = new SelectList(fullNames, "id", "fullName");
                return View();
                
            }
            else
            {
                return RedirectToAction("Edit", new { id = Int32.Parse(employee) });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
