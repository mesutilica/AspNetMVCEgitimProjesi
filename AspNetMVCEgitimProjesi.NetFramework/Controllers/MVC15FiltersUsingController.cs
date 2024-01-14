using AspNetMVCEgitimProjesi.NetFramework.Filters;
using System;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC15FiltersUsingController : Controller
    {
        [UserControl]
        public ActionResult Index()
        {
            ViewBag.Kullanici = HttpContext.Session["userguid"];
            return View();
        }
        [HandleError]
        //[HandleError(ExceptionType = typeof(NullReferenceException), View = "~/Views/Error/NullReference.cshtml")]
        public ActionResult HataYakalama()
        {
            ViewBag.Kullanici = HttpContext.Session["userguid"];
            string msg = null;
            ViewBag.Message = msg.Length;
            return View();
        }
    }
}
