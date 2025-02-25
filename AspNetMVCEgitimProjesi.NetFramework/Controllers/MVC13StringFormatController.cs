using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC13StringFormatController : Controller
    {
        // GET: MVC13StringFormat
        public ActionResult Index()
        {
            ViewBag.MusteriNo = string.Format("M{0:D6}", 1);
            ViewBag.SaticiNo = string.Format("S{0:D6}", 218);
            return View();
        }
    }
}