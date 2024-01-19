using AspNetMVCEgitimProjesi.NetCore.Extensions;
using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC12SessionController : Controller
    {
        private readonly UyeContext _context;

        public MVC12SessionController(UyeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SessionOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = _context.Uyeler.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre);
            if (kullanici != null)
            {
                HttpContext.Session.SetString("Kullanici", kullaniciAdi); // session da string olarak key value şeklinde değer saklayabiliriz
                HttpContext.Session.SetString("Sifre", sifre);
                HttpContext.Session.SetInt32("IsLoggedIn", 1);
                HttpContext.Session.SetString("UserGuid", Guid.NewGuid().ToString());
                HttpContext.Session.SetJson("uye", kullanici);
                return RedirectToAction("SessionOku");
            }
            else TempData["Mesaj"] = @"<div class='alert alert-danger'>Giriş Başarısız!</div>";
            return RedirectToAction("Index");
        }
        public IActionResult SessionOku()
        {
            //var kullanici = _context.Uyeler.FirstOrDefault();
            //HttpContext.Session.SetJson("uye", kullanici);
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
