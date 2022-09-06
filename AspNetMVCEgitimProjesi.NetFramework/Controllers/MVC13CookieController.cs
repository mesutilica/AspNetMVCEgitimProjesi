using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC13CookieController : Controller
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
            Response.Cookies.Remove("username");

            return RedirectToAction("CookieOku");
        }
    }
}