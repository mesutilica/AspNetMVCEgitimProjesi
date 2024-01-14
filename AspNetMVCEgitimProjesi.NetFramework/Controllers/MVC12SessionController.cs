using AspNetMVCEgitimProjesi.NetFramework.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC12SessionController : Controller
    {
        private UyeContext context = new UyeContext();
        // GET: MVC12Session
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost] // , ActionName("SessionOlustur")
        public ActionResult SessionOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = context.Uyeler.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre);
            if (kullanici != null)
            {
                Session["deger"] = "Admin"; //mvc de sessiona veri atma
                Session["userguid"] = Guid.NewGuid().ToString();
                return RedirectToAction("SessionOku");
            }
            else TempData["Mesaj"] = @"<div class='alert alert-danger'>Giriş Başarısız!</div>";
            return RedirectToAction("Index");
        }
        public ActionResult SessionOku()
        {
            TempData["SessionBilgi"] = Session["deger"]; // sessiondaki veriye ulaşım
            return View();
        }
        public ActionResult SessionSil()
        {
            HttpContext.Session.Remove("deger"); // deger isimli sessionu süresini beklemeden sil
            Session["userguid"] = null;
            return RedirectToAction("Index");
        }
    }
}