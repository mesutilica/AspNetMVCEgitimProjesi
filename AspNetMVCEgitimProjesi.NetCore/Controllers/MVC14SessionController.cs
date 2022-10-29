using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC14SessionController : Controller
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
        [HttpPost]
        public IActionResult SessionOlustur(string kullaniciAdi, string sifre)
        {
            if (kullaniciAdi == "admin" && sifre == "123456")
            {
                HttpContext.Session.SetString("Kullanici", "Admin"); // session da string olarak key value şeklinde değer saklayabiliriz
                return RedirectToAction("SessionOku");
            }
            // Session["deger"] = "Admin"; klasik .net mvc de sessiona veri atma bu şekildeydi
            return View();
        }
        public IActionResult SessionOku()
        {
            TempData["SessionBilgi"] = HttpContext.Session.GetString("Kullanici"); // sessiondaki veriye bu şekilde keye verdiğimiz isimle ulaşıyoruz
            // TempData["SessionBilgi"] = Session["deger"];  klasik .net mvc de sessiondaki veriye ulaşım bu şekildeydi
            return View();
        }
        [HttpPost]
        public IActionResult SessionSil()
        {
            HttpContext.Session.Remove("Kullanici"); // Kullanici isimli sessionu süresini beklemeden sil
            return RedirectToAction("SessionOku");
        }
    }
}
