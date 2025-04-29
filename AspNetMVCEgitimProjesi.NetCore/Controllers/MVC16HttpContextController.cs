using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC16HttpContextController : Controller
    {
        public IActionResult Index()
        {
            var mesaj = "RouteData controller : " + RouteData.Values["controller"];
            mesaj += "<hr/>Action : " + RouteData.Values["action"];
            mesaj += "<hr/>Id : " + RouteData.Values["id"];
            mesaj += "<hr/>QueryString Kelime : " + HttpContext.Request.Query["kelime"];
            //mesaj += "<hr/> Tam Url-GetDisplayUrl : " + UriHelper.GetDisplayUrl(Request);
            //mesaj += "<hr/> Tam Url-GetEncodedPathAndQuery : " + UriHelper.GetEncodedPathAndQuery(Request);
            TempData["mesaj"] = mesaj;
            return View();
        }
    }
}
