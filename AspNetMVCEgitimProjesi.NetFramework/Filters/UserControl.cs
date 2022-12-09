using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Filters
{
    public class UserControl : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var UserGuid = context.HttpContext.Session["userguid"];
            var userguid = context.HttpContext.Request.Cookies["userguid"];
            if (userguid == null) context.Result = new RedirectResult("/MVC11Session?msg=AccessDenied");
            base.OnActionExecuting(context);
        }
    }
}
