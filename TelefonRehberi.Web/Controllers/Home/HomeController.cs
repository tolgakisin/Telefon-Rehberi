using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Data.Models;

namespace TelefonRehberi.Web.Controllers {
    public class HomeController : Controller {

        TelefonRehberiEntities ctx = new TelefonRehberiEntities();

        public ActionResult Index(string q, int? page, string currentFilter) {

            var employees = ctx.Employee.OrderBy(x => x.name).ToList();

            if (q != null)
                page = 1;
            else
                q = currentFilter;

            ViewBag.CurrentFilter = q;

            if (!string.IsNullOrEmpty(q))
                employees = employees.Where(x => x.name.ToUpper().Contains(q.ToUpper()) || x.surname.ToUpper().Contains(q.ToUpper()) || x.phone.ToUpper().Contains(q.ToUpper())).ToList();

            int pageSize = 5;
            int pageNumber = page ?? 1;

            ViewBag.Employees = employees;

            return View(employees.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id) {
            if (id == null)
                return HttpNotFound();

            Employee emp = ctx.Employee.SingleOrDefault(x => x.employeeID == id);
            if (emp.managerID != null)
                ViewBag.ManagerName = ctx.Employee.SingleOrDefault(x => x.employeeID == emp.managerID).name + " " + ctx.Employee.SingleOrDefault(x => x.employeeID == emp.managerID).surname;
            
            if (emp == null)
                return HttpNotFound();

            return View(emp);
        }

        
    }
}