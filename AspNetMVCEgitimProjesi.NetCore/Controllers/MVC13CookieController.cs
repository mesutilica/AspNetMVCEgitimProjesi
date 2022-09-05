using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC13CookieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CookieOlustur()
        {
            CookieOptions cookie = new()
            {
                Expires = DateTime.Now.AddMinutes(1) // cookie ye 1 dk lık bitiş süresi tanımladık
            };
            Response.Cookies.Append("username", "Admin", cookie);
            Response.Cookies.Append("userguid", "1235479893-sdfsfs-sdfsg", cookie);
            return View();
        }
        public IActionResult CookieOku()
        {
            TempData["kullaniciadi"] = Request.Cookies["username"]; // Request.Cookies ile username isimli cookie yi okuyoruz
            TempData["kullaniciguid"] = Request.Cookies["userguid"];
            return View();
        }
        public IActionResult CookieSil()
        {
            Response.Cookies.Delete("username");
            Response.Cookies.Delete("userguid");

            return RedirectToAction("CookieOku");
        }
    }
}
