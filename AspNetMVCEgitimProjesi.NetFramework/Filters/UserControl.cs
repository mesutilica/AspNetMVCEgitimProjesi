using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Filters
{
    public class UserControl : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var UserGuid = context.HttpContext.Session["userguid"];
            var userguid = context.HttpContext.Request.Cookies["userguid"];
            if (UserGuid == null) 
                context.Result = new RedirectResult("/MVC12Session?msg=AccessDenied");
            base.OnActionExecuting(context);
        }
    }
}
