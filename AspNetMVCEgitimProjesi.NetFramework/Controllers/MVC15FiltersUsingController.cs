﻿using AspNetMVCEgitimProjesi.NetFramework.Filters;
using AspNetMVCEgitimProjesi.NetFramework.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC15FiltersUsingController : Controller
    {
        private UyeContext db = new UyeContext();

        public ActionResult Index()
        {
            return View();
        }
        [UserControl]
        public ActionResult UyelikBilgilerim()
        {
            return View();
        }
        [Authorize]
        public ActionResult UyeGuncelle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uyeler.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UyeGuncelle(Uye uye)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uye);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Uye uye)
        {
            try
            {
                var kullanici = db.Uyeler.Any(u => u.Email == uye.Email && u.Sifre == uye.Sifre);
                if (kullanici)
                {
                    Session["Admin"] = kullanici;
                    FormsAuthentication.SetAuthCookie(uye.Email, true);
                    if (Request.QueryString["ReturnUrl"] != null) // eğer adres çubuğunda ReturnUrl diye bir değer varsa
                    {
                        return Redirect(Request.QueryString["ReturnUrl"]); // oturum açıldıktan sonra kullanıcıyı kaldığı yere dönürmek için returnurl deki adrese yönlendir
                    }
                    return RedirectToAction("Index"); // ReturnUrl boşsa anasayfaya yönlendir
                }
                else
                {
                    ModelState.AddModelError("", "Giriş Başarısız!");
                }
            }
            catch (System.Exception hata)
            {
                ModelState.AddModelError("", "Hata Oluştu!");
                //Todo: burada loglama yapılıp hata kaydedilmeli!
                //throw;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        [HandleError]
        //[HandleError(ExceptionType = typeof(NullReferenceException), View = "~/Views/Error/NullReference.cshtml")]
        [OutputCache(Duration = 10)] // Keşleme attribute ü
        public ActionResult HataYakalama()
        {
            ViewBag.Kullanici = HttpContext.Session["userguid"];
            string msg = null;
            ViewBag.Message = msg.Length;
            return View();
        }
    }
}
