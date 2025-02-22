using AspNetMVCEgitimProjesi.NetFramework.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC11CookieController : Controller
    {
        private UyeContext context = new UyeContext();
        // GET: MVC11Cookie
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CookieOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = context.Uyeler.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre);
            if (kullanici != null)
            {
                Response.Cookies.Add(new HttpCookie("userguid", Guid.NewGuid().ToString()));
                
                var cookieAyarlari = new HttpCookie("username", "Admin")
                {
                    Expires = DateTime.Now.AddMinutes(1) // cookie ye 1 dk lık bitiş süresi tanımladık
                };
                HttpContext.Response.Cookies.Add(cookieAyarlari); // .net framework de HttpContext ile oluşturuyoruz
                
                return RedirectToAction("CookieOku");
            }
            else
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Giriş Başarısız!</div>";
            return RedirectToAction("Index");
        }
        public ActionResult CookieOku()
        {
            if (HttpContext.Request.Cookies["username"] == null || HttpContext.Request.Cookies["userguid"] == null)
            {
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Lütfen Giriş Yapınız!</div>";
                return RedirectToAction("Index");
            }
            TempData["kullaniciAdi"] = HttpContext.Request.Cookies["username"].Value;
            TempData["kullaniciguid"] = HttpContext.Request.Cookies["userguid"].Value;
            return View();
        }
        public ActionResult CookieSil()
        {
            if (HttpContext.Request.Cookies["username"] != null)
                HttpContext.Response.Cookies["username"].Expires = DateTime.Now.AddSeconds(-1);
            if (HttpContext.Request.Cookies["userguid"] != null)
                HttpContext.Response.Cookies["userguid"].Expires = DateTime.Now.AddSeconds(-1);
            return RedirectToAction("CookieOku");
        }
    }
}