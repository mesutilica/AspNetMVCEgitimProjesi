using AspNetMVCEgitimProjesi.NetCore.Extensions;
using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Http;
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
                HttpContext.Session.SetString("deger", "Admin"); //mvc de sessiona veri atma
                HttpContext.Session.SetString("userguid", Guid.NewGuid().ToString());
                HttpContext.Session.SetString("username", kullanici.KullaniciAdi);
                HttpContext.Session.SetString("kullanici", kullaniciAdi); // session da string olarak key value şeklinde değer saklayabiliriz
                
                HttpContext.Session.SetInt32("kullaniciId", kullanici.Id);
                
                //HttpContext.Session.SetJson("uye", kullanici);
                HttpContext.Session.Set("uye", kullanici);
                return RedirectToAction("SessionOku");
            }
            else
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Giriş Başarısız!</div>";
            return RedirectToAction("Index");
        }
        public IActionResult SessionOku()
        {
            if (HttpContext.Session.GetString("username") == null || HttpContext.Session.GetString("userguid") == null)
            {
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Lütfen Giriş Yapınız!</div>";
                return RedirectToAction("Index");
            }
            TempData["SessionBilgi"] = HttpContext.Session.GetString("deger"); // sessiondaki veriye ulaşım
            TempData["kullaniciAdi"] = HttpContext.Session.GetString("username");
            TempData["kullaniciguid"] = HttpContext.Session.GetString("userguid");
            return View();
        }
        public IActionResult SessionSil()
        {
            HttpContext.Session.Remove("userguid");
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("kullanici"); // Kullanici isimli sessionu süresini beklemeden sil
            HttpContext.Session.Clear();
            return RedirectToAction("SessionOku");
        }
    }
}
