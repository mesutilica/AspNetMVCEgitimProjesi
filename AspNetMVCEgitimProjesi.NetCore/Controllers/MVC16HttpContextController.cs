using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC16HttpContextController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public MVC16HttpContextController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public IActionResult Index()
        {
            var mesaj = "_contextAccessor Controller : " + _contextAccessor.HttpContext.GetRouteValue("Controller");
            mesaj += "<hr/>_contextAccessor Action : " + _contextAccessor.HttpContext.GetRouteValue("Action");
            mesaj += "<hr/>HttpContext Action : " + HttpContext.GetRouteValue("Action");
            mesaj += "<hr/>HttpContext Id : " + HttpContext.GetRouteValue("id");
            mesaj += "<hr/> Kelime : " + HttpContext.Request.Query["kelime"];
            mesaj += "<hr/> Tam Url-GetEncodedUrl : " + UriHelper.GetEncodedUrl(Request);
            mesaj += "<hr/> Tam Url-GetDisplayUrl : " + UriHelper.GetDisplayUrl(Request);
            mesaj += "<hr/> Tam Url-GetEncodedPathAndQuery : " + UriHelper.GetEncodedPathAndQuery(Request);
            TempData["mesaj"] = mesaj;
            return View();
        }
    }
}
