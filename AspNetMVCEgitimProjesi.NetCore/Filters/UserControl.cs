using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetMVCEgitimProjesi.NetCore.Filters
{
    public class UserControl : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var kullanici = context.HttpContext.Session.GetString("deger");
            if (kullanici == null) context.Result = new RedirectResult("/MVC12Session?msg=AccessDenied");
            base.OnActionExecuting(context);
        }
    }
}
