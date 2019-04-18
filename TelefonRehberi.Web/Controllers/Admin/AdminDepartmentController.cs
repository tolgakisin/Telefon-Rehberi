using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Data.Models;
using TelefonRehberi.Web.Filters;

namespace TelefonRehberi.Web.Controllers.Admin {
    [Auth]
    public class AdminDepartmentController : Controller {

        TelefonRehberiEntities ctx = new TelefonRehberiEntities();

        public ActionResult Index() {
            ViewBag.DepartmentList = ctx.Department.OrderBy(x=>x.name).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department dep) {
            if (ModelState.IsValid) {
                ctx.Department.Add(dep);
                try {
                    ctx.SaveChanges();
                    return RedirectToAction("Index", "AdminDepartment");
                } catch (Exception) {
                    return RedirectToAction("Index", "AdminDepartment");
                }
            }
            return RedirectToAction("Index", "AdminDepartment");

        }

        //public ActionResult Edit(int? id) {
        //    Departman dep = ctx.Departman.SingleOrDefault(x => x.departmanID == id);
        //    return PartialView(dep);
        //}

        public ActionResult Edit(int? id) {
            if (id == null)
                return HttpNotFound();

            Department dep = ctx.Department.FirstOrDefault(x => x.departmentID == id);
            ViewBag.EmployeeManager = ctx.Employee.ToList();
            //ViewBag.EmployeeListUnderOfDepartment = ctx.Employee.Where(x => x.departmanID == dep.departmanID).ToList();
            if (dep == null)
                return HttpNotFound();

            return View(dep);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Department dep) {
            Department departman = ctx.Department.FirstOrDefault(x => x.departmentID == id);
            departman.name = dep.name;
            ctx.SaveChanges();
            return RedirectToAction("Edit", "AdminDepartment");
        }

        [HttpPost]
        public string Delete(int? id) {
            if (id == null)
                return "error";

            Department dep = ctx.Department.FirstOrDefault(x => x.departmentID == id);

            if (ctx.Employee.FirstOrDefault(x => x.departmentID == dep.departmentID) == null) {
                ctx.Department.Remove(dep);
                try {
                    ctx.SaveChanges();
                    return "success";
                } catch (Exception) {
                    return "error";
                }
            } else {
                return "departmentError";
            }
        }
    }
}