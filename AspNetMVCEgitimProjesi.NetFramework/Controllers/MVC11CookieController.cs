using System;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC11CookieController : Controller
    {
        // GET: MVC13Cookie
        public ActionResult Index()
        {
            return View();
        }
        [Route("CookieOlustur"), HttpPost]
        public ActionResult CookieOlustur(string kullaniciAdi, string sifre)
        {
            if (kullaniciAdi == "admin" && sifre == "123")
            {
                HttpCookie cookie = new HttpCookie("username", "Admin")
                {
                    Expires = DateTime.Now.AddMinutes(1) // cookie ye 1 dk lık bitiş süresi tanımladık
                };
                HttpContext.Response.Cookies.Add(cookie); // .net framework de HttpContext ile oluşturuyoruz
                Response.Cookies.Add(new HttpCookie("userguid", Guid.NewGuid().ToString()));
                return RedirectToAction("CookieOku");
            }
            TempData["mesaj"] = "Giriş Başarısız!";
            return RedirectToAction("Index");
        }
        public ActionResult CookieOku()
        {
            if (HttpContext.Request.Cookies["username"] != null)
                TempData["mesaj"] = HttpContext.Request.Cookies["username"].Value; // Request.Cookies ile username isimli cookie yi okuyoruz // .value demeden netframework mvc de değere ulaşamadık

            if (HttpContext.Request.Cookies["userguid"] != null)
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