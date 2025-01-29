using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC11CookieController : Controller
    {
        private readonly UyeContext _context;

        public MVC11CookieController(UyeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CookieOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = _context.Uyeler.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre);
            if (kullanici != null)
            {
                var cookieAyarlari = new CookieOptions()
                {
                    Expires = DateTime.Now.AddMinutes(1) // cookie ye 1 dk lık bitiş süresi tanımladık
                };
                Response.Cookies.Append("username", kullaniciAdi, cookieAyarlari);
                Response.Cookies.Append("sifre", sifre, cookieAyarlari);
                Response.Cookies.Append("userguid", Guid.NewGuid().ToString());
                return RedirectToAction("CookieOku");
            }
            else
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Giriş Başarısız!</div>";
            return View("Index");
        }
        public IActionResult CookieOku()
        {
            if (HttpContext.Request.Cookies["username"] == null || HttpContext.Request.Cookies["userguid"] == null)
            {
                TempData["Mesaj"] = "Lütfen Giriş Yapınız!";
                return RedirectToAction("Index");
            }
            TempData["kullaniciAdi"] = HttpContext.Request.Cookies["username"];
            TempData["kullaniciguid"] = HttpContext.Request.Cookies["userguid"];
            return View();
        }
        public IActionResult CookieSil()
        {
            Response.Cookies.Delete("username");
            Response.Cookies.Delete("sifre");
            Response.Cookies.Delete("userguid");

            return RedirectToAction("CookieOku");
        }
    }
}
