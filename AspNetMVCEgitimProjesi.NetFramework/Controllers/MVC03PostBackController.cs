using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC03PostBackController : Controller
    {
        // GET: MVC03PostBack
        [HttpGet] // Eğer bir action un üstüne hiçbir metot attribute ü yazılmamışsa varsayılan metot httpget dir
        public ActionResult Index(string kelime)
        {
            ViewBag.Mesaj = "Get metoduyla gönderilen değer : " + kelime;
            return View();
        }
        [HttpPost] // Sayfada post metodu çalıştırılırsa aşağıdaki action çalışır
        public ActionResult Index()
        {
            return View();
        }
    }
}