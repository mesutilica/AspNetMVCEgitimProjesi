using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC13CookieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CookieOlustur(string kullaniciAdi, string sifre)
        {
            if (kullaniciAdi == "admin" && sifre == "123456")
            {
                CookieOptions cookieAyarlari = new()
                {
                    Expires = DateTime.Now.AddMinutes(1) // cookie ye 1 dk lık bitiş süresi tanımladık
                };
                Response.Cookies.Append("kullaniciAdi", kullaniciAdi, cookieAyarlari);
                Response.Cookies.Append("sifre", sifre, cookieAyarlari);
                Response.Cookies.Append("userguid", Guid.NewGuid().ToString());
                return RedirectToAction("CookieOku");
            }
            return RedirectToAction("Index");
        }
        public IActionResult CookieOku()
        {
            if (Request.Cookies["userguid"] is null) return RedirectToAction("Index");
            TempData["kullaniciadi"] = Request.Cookies["kullaniciAdi"]; // Request.Cookies ile username isimli cookie yi okuyoruz
            TempData["kullaniciguid"] = Request.Cookies["userguid"];
            return View();
        }
        public IActionResult CookieSil()
        {
            Response.Cookies.Delete("kullaniciAdi");
            Response.Cookies.Delete("sifre");
            Response.Cookies.Delete("userguid");

            return RedirectToAction("CookieOku");
        }
    }
}
