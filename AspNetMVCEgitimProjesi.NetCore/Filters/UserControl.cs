using AspNetMVCEgitimProjesi.NetCore.Extensions;
using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace AspNetMVCEgitimProjesi.NetCore.Filters
{
    public class UserControl : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Bir action çalışmadan önce yaptırmak istediklerimizi burada yaptırabiliriz
            Log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var SessionUserGuid = context.HttpContext.Session.GetString("UserGuid");
            var CookiesUserguid = context.HttpContext.Request.Cookies["userguid"]; 
            var uye = context.HttpContext.Session.GetJson<Uye>("uye");
            if (uye == null)
                context.Result = new RedirectResult("/MVC12Session?msg=AccessDenied");
            base.OnActionExecuting(context);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
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
