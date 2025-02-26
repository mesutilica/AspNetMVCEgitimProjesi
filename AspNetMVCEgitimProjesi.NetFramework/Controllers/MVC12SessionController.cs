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
                Session["username"] = kullanici.KullaniciAdi;
                Session["kullanici"] = kullanici;
                return RedirectToAction("SessionOku");
            }
            else
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Giriş Başarısız!</div>";
            return RedirectToAction("Index");
        }
        public ActionResult SessionOku()
        {
            if (Session["username"] == null || Session["userguid"] == null)
            {
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Lütfen Giriş Yapınız!</div>";
                return RedirectToAction("Index");
            }
            TempData["SessionBilgi"] = Session["deger"]; // sessiondaki veriye ulaşım
            TempData["kullaniciAdi"] = Session["username"];
            TempData["kullaniciguid"] = Session["userguid"];
            return View();
        }
        public ActionResult SessionSil()
        {
            Session.Remove("deger"); // deger isimli sessionu süresini beklemeden sil
            //Session["userguid"] = null;
            Session.RemoveAll(); // tüm sessionları sil
            return RedirectToAction("Index");
        }
    }
}