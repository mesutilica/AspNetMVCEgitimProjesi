using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC13StringFormatController : Controller
    {
        // GET: MVC12StringFormat
        public ActionResult Index()
        {
            ViewBag.Data = string.Format("M{0:D6}", 1);
            ViewBag.Data2 = string.Format("M{0:D6}", 218);
            return View();
        }
    }
}