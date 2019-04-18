using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Data.Models;
using TelefonRehberi.Web.Filters;

namespace TelefonRehberi.Web.Controllers {
    [Auth]
    public class AdminEmployeeController : Controller {

        TelefonRehberiEntities ctx = new TelefonRehberiEntities();
        public ActionResult Index(string q, int? page,string currentFilter) {

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

        public List<SelectListItem> GetDepartmentList() {
            return ctx.Department
                .Select(x => new SelectListItem {
                    Value = x.departmentID.ToString(),
                    Text = x.name
                }).ToList();
        }

        public List<SelectListItem> GetManagerList() {
            return ctx.Employee
                .Select(x => new SelectListItem {
                    Value = x.employeeID.ToString(),
                    Text = x.name + " " + x.surname
                }).ToList();
        }

        public ActionResult Create() {
            if (TempData["Success"] != null) {
                ViewBag.Success = TempData["Success"].ToString();
                TempData.Remove("Success");
            }
            
            ViewBag.DepartmentList = new SelectList(GetDepartmentList(), "Value", "Text");
            ViewBag.ManagerList = new SelectList(GetManagerList(), "Value", "Text");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp) {

            ViewBag.DepartmentList = new SelectList(GetDepartmentList(), "Value", "Text");
            ViewBag.ManagerList = new SelectList(GetManagerList(), "Value", "Text");

            if (ModelState.IsValid) {
                ctx.Employee.Add(emp);
                ctx.SaveChanges();

                if (ctx.Employee.FirstOrDefault(x => x.employeeID == emp.employeeID) != null) {
                    TempData["Success"] = "The Employee has been created successfully.";
                    return RedirectToAction("Create", "AdminEmployee");
                } else {
                    TempData["Error"] = "An error has occured.";
                    return View();
                }

            }
            TempData["Error"] = "An error has occured.";
            return View();
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

        public ActionResult Edit(int? id) {
            if (id == null)
                return HttpNotFound();

            ViewBag.DepartmentList = new SelectList(GetDepartmentList(), "Value", "Text");
            ViewBag.ManagerList = new SelectList(GetManagerList(), "Value", "Text");

            var emp = ctx.Employee.SingleOrDefault(x => x.employeeID == id);
            
            if (emp == null)
                return HttpNotFound();

            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Employee emp) {
            if (id == null) {
                return HttpNotFound();
            }

            ViewBag.DepartmentList = new SelectList(GetDepartmentList(), "Value", "Text");
            ViewBag.ManagerList = new SelectList(GetManagerList(), "Value", "Text");

            if (ModelState.IsValid) {
                ctx.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index", "AdminEmployee");
            }

            return View(emp);
        }

        [HttpPost]
        public string Delete(int? id) {

            Employee emp = ctx.Employee.SingleOrDefault(x => x.employeeID == id);

            if (ctx.Employee.FirstOrDefault(x => x.managerID == emp.employeeID) == null) {
                ctx.Employee.Remove(emp);
                try {
                    ctx.SaveChanges();
                    return "success";
                } catch (Exception) {
                    return "error";
                }
            } else
                return "managerError";

        }
    }
}