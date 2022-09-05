using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC12SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SessionOlustur()
        {
            HttpContext.Session.SetString("deger", "Admin"); // session da string olarak key value şeklinde değer saklayabiliriz
            // Session["deger"] = "Admin"; klasik .net mvc de sessiona veri atma bu şekildeydi
            return View();
        }
        public IActionResult SessionOku()
        {
            TempData["SessionBilgi"] = HttpContext.Session.GetString("deger"); // sessiondaki veriye bu şekilde keye verdiğimiz isimle ulaşıyoruz
            // TempData["SessionBilgi"] = Session["deger"];  klasik .net mvc de sessiondaki veriye ulaşım bu şekildeydi
            return View();
        }
        public IActionResult SessionSil()
        {
            HttpContext.Session.Remove("deger"); // deger isimli sessionu süresini beklemeden sil
            return View();
        }
    }
}
