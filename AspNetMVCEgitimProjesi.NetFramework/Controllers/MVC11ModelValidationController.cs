using AspNetMVCEgitimProjesi.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC11ModelValidationController : Controller
    {
        // GET: MVC11ModelValidation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UyeListesi()
        {
            var uyeListesi = new List<Uye>()
            {
                new Uye() { Id = 1, Ad = "Akın", Soyad = "Malkoç", Email ="akin@siteadi.com"  },
                new Uye() {  Id = 2, Ad = "Mert", Soyad = "Temel", Email ="mert@siteadi.com"  }
            };
            uyeListesi.Add(new Uye() { Id = 1453, Ad = "Fatih", Soyad = "Sultan", Email = "fatih@sultan.net" });

            return View(uyeListesi); // Ekrana modeli view içerisinde gönderebiliyoruz
        }
        public ActionResult YeniUye()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniUye(Uye uye)
        {
            if (ModelState.IsValid) // Eğer modeldeki validasyon kurallarına uyulmuşsa, tersi için !ModelState.IsValid
            {
                // Parametreyle gelen uye nesnesini burada veritabanına kaydedebiliriz
                ViewBag.Uye = uye.Ad + " " + uye.Soyad + " İsimli üye kaydı başarıyla gerçekleşti..";
            }
            if (!ModelState.IsValid) // model kuralları geçersizse
            {
                ViewBag.Uye = "Lütfen gerekli alanları doldurunuz!";
            }
            return View(uye);
        }
        public ActionResult UyeDuzenle(int? id) // Üye düzenle sayfasına adres çubuğundaki Route üzerinden id bilgisi gönderilir ve bu id ile eşleşen kayıt veritabanından çekilerek ekrana gönderilir.
        {
            var uyeBilgileri = new Uye() { Id = 1, Ad = "Akın", Soyad = "Malkoç", Email = "akin@siteadi.com" };

            return View(uyeBilgileri);
        }
        [HttpPost]
        public ActionResult UyeDuzenle(Uye uye)
        {
            if (ModelState.IsValid)
            {
                // Eğer validasyon kurallarına uygun veri gönderilmişse kaydı güncelle
                return RedirectToAction("UyeListesi");
            }
            return View(uye);
        }
        public ActionResult UyeSil(int? id)
        {
            var uyeBilgileri = new Uye() { Id = 1, Ad = "Akın", Soyad = "Malkoç", Email = "akin@siteadi.com" };

            return View(uyeBilgileri);
        }
        [HttpPost]
        public ActionResult UyeSil(Uye uye)
        {
            // Kaydı sil
            return RedirectToAction("UyeListesi"); // sayfayı listeye yönlendir
        }
    }
}