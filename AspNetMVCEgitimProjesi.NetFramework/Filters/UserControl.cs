using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetMVCEgitimProjesi.NetFramework.Filters
{
    public class UserControl : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Bir action çalıştıktan sonra yaptırmak istediklerimizi burada yapabiliriz
            Log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Bir action çalışmadan önce yaptırmak istediklerimizi burada yaptırabiliriz
            var SessionUserGuid = filterContext.HttpContext.Session["userguid"];
            var CookiesUserguid = filterContext.HttpContext.Request.Cookies["userguid"];
            var uye = filterContext.HttpContext.Session["kullanici"];
            if (uye == null)
                filterContext.Result = new RedirectResult("/MVC12Session?msg=AccessDenied");
            base.OnActionExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            // Bir action çalıştıktan sonra yaptırmak istediklerimizi burada yapabiliriz
            Log("OnResultExecuted", filterContext.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            // Bir action çalıştıktan sonra yaptırmak istediklerimizi burada yapabiliriz
            Log("OnResultExecuting ", filterContext.RouteData);
        }
        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0}- controller:{1} action:{2}", methodName,
                                                                        controllerName,
                                                                        actionName);
            Debug.WriteLine(message);
        }
    }
}
