﻿using AspNetMVCEgitimProjesi.NetFramework.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC05ModelValidationController : Controller
    {
        static List<Uye> uyeListesi = new List<Uye>()
         {
             new Uye() { Id = 1, Ad = "Alp", Soyad = "Arslan", Email ="alp@siteadi.com"  },
             new Uye() { Id = 2, Ad = "Mert", Soyad = "Temel", Email ="mert@siteadi.com"  },
             new Uye() { Id = 3, Ad = "Mesut", Soyad = "Ilıca", Email = "mesut@gmail.net" }
         };

        // GET: MVC11ModelValidation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UyeListesi()
        {
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
                uye.Id = uyeListesi.Count + 1;
                uyeListesi.Add(uye);
                // Parametreyle gelen uye nesnesini burada veritabanına kaydedebiliriz
                return RedirectToAction("UyeListesi");
            }
            if (!ModelState.IsValid) // model kuralları geçersizse
            {
                ViewBag.Uye = "Lütfen gerekli alanları doldurunuz!";
            }
            return View(uye);
        }
        public ActionResult UyeDuzenle(int? id) // Üye düzenle sayfasına adres çubuğundaki Route üzerinden id bilgisi gönderilir ve bu id ile eşleşen kayıt veritabanından çekilerek ekrana gönderilir.
        {
            var uyeBilgileri = uyeListesi.FirstOrDefault(u => u.Id == id);

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
            var uyeBilgileri = uyeListesi.FirstOrDefault(u => u.Id == id);

            return View(uyeBilgileri);
        }
        [HttpPost]
        public ActionResult UyeSil(int? id, Uye uye)
        {
            var uyeBilgileri = uyeListesi.FirstOrDefault(u => u.Id == id);
            uyeListesi.Remove(uyeBilgileri);
            // Kaydı sil
            return RedirectToAction("UyeListesi"); // sayfayı listeye yönlendir
        }
    }
}