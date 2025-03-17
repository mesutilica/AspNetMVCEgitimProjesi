using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC16HttpContextController : Controller
    {
        // GET: MVC16HttpContext
        public ActionResult Index()
        {
            var mesaj = "RouteData controller : " + RouteData.Values["controller"];
            mesaj += "<hr/>Action : " + RouteData.Values["action"];
            mesaj += "<hr/>Id : " + RouteData.Values["id"];
            mesaj += "<hr/>QueryString Kelime : " + HttpContext.Request.QueryString["kelime"];
            TempData["mesaj"] = mesaj;
            return View();
        }
    }
}