using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC12SessionController : Controller
    {
        // GET: MVC12Session
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SessionOlustur()
        {
            Session["deger"] = "Admin"; //klasik .net mvc de sessiona veri atma bu şekildeydi
            return View();
        }
        public ActionResult SessionOku()
        {
            TempData["SessionBilgi"] = Session["deger"]; // klasik .net mvc de sessiondaki veriye ulaşım bu şekildeydi
            return View();
        }
        public ActionResult SessionSil()
        {
            HttpContext.Session.Remove("deger"); // deger isimli sessionu süresini beklemeden sil
            return View();
        }
    }
}