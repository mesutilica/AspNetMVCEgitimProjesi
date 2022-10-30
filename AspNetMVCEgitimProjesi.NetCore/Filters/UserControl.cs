using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetMVCEgitimProjesi.NetCore.Filters
{
    public class UserControl : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var UserGuid = context.HttpContext.Session.GetString("UserGuid");
            var userguid = context.HttpContext.Request.Cookies["userguid"];
            if (userguid == null) context.Result = new RedirectResult("/MVC14Session?msg=AccessDenied");
            base.OnActionExecuting(context);
        }
    }
}
