using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelefonRehberi.Web.Filters {
    public class Auth : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (HttpContext.Current.Session["Login"] == null) {
                filterContext.Result = new RedirectToRouteResult("Login", new System.Web.Routing.RouteValueDictionary("Login"));
            }
        }
    }
}