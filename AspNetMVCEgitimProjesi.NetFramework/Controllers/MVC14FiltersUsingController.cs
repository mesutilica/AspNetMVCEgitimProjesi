using AspNetMVCEgitimProjesi.NetFramework.Filters;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC14FiltersUsingController : Controller
    {
        [UserControl]
        public ActionResult Index()
        {
            ViewBag.Kullanici = HttpContext.Session["userguid"];
            return View();
        }
    }
}
