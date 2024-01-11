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
        public ActionResult CookieOlustur()
        {
            HttpCookie cookie = new HttpCookie("username", "Admin")
            {
                Expires = DateTime.Now.AddMinutes(10) // cookie ye 1 dk lık bitiş süresi tanımladık
            };

            HttpContext.Response.Cookies.Add(cookie); // .net framework de HttpContext ile oluşturuyoruz
            return View();
        }
        public ActionResult CookieOku()
        {
            TempData["kullaniciadi"] = HttpContext.Request.Cookies["username"].Value; // Request.Cookies ile username isimli cookie yi okuyoruz // .value demeden netframework mvc de değere ulaşamadık
            return View();
        }
        public ActionResult CookieSil()
        {
            if (HttpContext.Request.Cookies["username"] != null)
                HttpContext.Response.Cookies["username"].Expires = DateTime.Now.AddSeconds(-1);
            return RedirectToAction("CookieOku");
        }
    }
}