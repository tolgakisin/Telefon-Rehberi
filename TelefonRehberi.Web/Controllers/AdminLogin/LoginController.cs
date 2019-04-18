using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Data.Models;
using TelefonRehberi.Web.Filters;
using TelefonRehberi.Web.Models;

namespace TelefonRehberi.Web.Controllers.AdminLogin {
    public class LoginController : Controller {

        TelefonRehberiEntities ctx = new TelefonRehberiEntities();

        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(Login loginModel) {
            var userDetails = ctx.Login.Where(x => x.username == loginModel.username.Trim() && x.password == loginModel.password.Trim()).FirstOrDefault();
            if (userDetails != null) {
                Session.Add("Login", userDetails);
                return RedirectToAction("Index", "AdminEmployee");
            }
            ViewBag.Error = "error message";
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Logout() {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        [Auth]
        public ActionResult ChangePassword(int? id) {
            if (id == null) {
                ViewBag.NotFoundUser = "User is not found";
                return View();
            }

            Login login = ctx.Login.SingleOrDefault(x => x.loginID == id);

            if (login == null) {
                ViewBag.NotFoundUser = "User is not found";
                return View();
            }

            LoginVM loginvm = new LoginVM();
            loginvm.username = login.username;
            loginvm.loginID = login.loginID;

            return View(loginvm);
        }

        [Auth]
        [HttpPost]
        public ActionResult ChangePassword(LoginVM loginvm, int? id) {
            if (loginvm == null) {
                ViewBag.NotFoundUser = "User is not found";
                return View();
            }

            Login login = ctx.Login.SingleOrDefault(x => x.loginID == id);

            if (loginvm.newPassword.Trim() == loginvm.confirmPassword.Trim()) {
                login.password = loginvm.newPassword;
                ctx.SaveChanges();
                ViewBag.Success = "Success";

                //Session.Abandon();
                //Session.Add("Login", login);

                return View();
            } else {
                ViewBag.NotSamePassword = "Please enter the same value";
            }

            


            if (login == null) {
                ViewBag.NotFoundUser = "User is not found";
                return View();
            }

            return View(); ;
        }
    }
}