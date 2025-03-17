using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC16HttpContextController : Controller
    {
        public IActionResult Index()
        {
            var mesaj = "RouteData controller : " + HttpContext.GetRouteValue("Controller");
            mesaj += "<hr/>Action : " + HttpContext.GetRouteValue("Action");
            mesaj += "<hr/>Id : " + HttpContext.GetRouteValue("id");
            mesaj += "<hr/>QueryString Kelime : " + HttpContext.Request.Query["kelime"];
            mesaj += "<hr/> Tam Url-GetEncodedUrl : " + UriHelper.GetEncodedUrl(Request);
            mesaj += "<hr/> Tam Url-GetDisplayUrl : " + UriHelper.GetDisplayUrl(Request);
            mesaj += "<hr/> Tam Url-GetEncodedPathAndQuery : " + UriHelper.GetEncodedPathAndQuery(Request);
            TempData["mesaj"] = mesaj;
            return View();
        }
    }
}
