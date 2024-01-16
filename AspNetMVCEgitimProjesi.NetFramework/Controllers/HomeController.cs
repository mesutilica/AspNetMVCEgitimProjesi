using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hakkımızda sayfası";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim sayfası";

            return View();
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            //Burada hatayı logluyoruz

            //Redirect to action
            filterContext.Result = RedirectToAction("Error", "Home");

            // Özel hata sayfası yönlendirme
            //filterContext.Result = new ViewResult
            //{
            //    ViewName = "~/Views/Error/InternalError.cshtml"
            //};
        }
    }
}