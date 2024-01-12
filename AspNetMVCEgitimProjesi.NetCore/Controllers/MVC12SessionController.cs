using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC12SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SessionOlustur(string kullaniciAdi, int sifre)
        {
            if (kullaniciAdi == "admin" && sifre == 123)
            {
                HttpContext.Session.SetString("Kullanici", kullaniciAdi); // session da string olarak key value şeklinde değer saklayabiliriz
                HttpContext.Session.SetInt32("Sifre", sifre);
                HttpContext.Session.SetInt32("IsLoggedIn", 1);
                HttpContext.Session.SetString("UserGuid", Guid.NewGuid().ToString());
                return RedirectToAction("SessionOku");
            }
            // Session["deger"] = "Admin"; klasik .net mvc de sessiona veri atma bu şekildeydi
            return View();
        }
        public IActionResult SessionOku()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SessionSil()
        {
            HttpContext.Session.Remove("Kullanici"); // Kullanici isimli sessionu süresini beklemeden sil
            HttpContext.Session.Clear();
            return RedirectToAction("SessionOku");
        }
    }
}
