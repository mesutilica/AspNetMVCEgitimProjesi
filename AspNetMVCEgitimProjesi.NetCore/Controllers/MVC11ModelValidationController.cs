using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC11ModelValidationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UyeListesi()
        {
            var uyeListesi = new List<Uye>()
            {
                new Uye() { Id = 1, Ad = "Murat", Soyad = "Malkoçoğlu", Email ="akin@siteadi.com"  },
                new Uye() {  Id = 2, Ad = "Alp", Soyad = "Arslan", Email ="alp@siteadi.com"  },
                new Uye() {  Id = 3, Ad = "Pusat", Soyad = "Kılıç", Email ="pusat@siteadi.com"  }
            };
            uyeListesi.Add(new Uye() { Id = 1453, Ad = "Fatih", Soyad = "Sultan", Email = "fatih@sultan.net" });

            return View(uyeListesi); // Ekrana modeli view içerisinde gönderebiliyoruz
        }
        public IActionResult YeniUye()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniUye(Uye uye)
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
        public IActionResult UyeDuzenle(int? id) // Üye düzenle sayfasına adres çubuğundaki Route üzerinden id bilgisi gönderilir ve bu id ile eşleşen kayıt veritabanından çekilerek ekrana gönderilir.
        {
            var uyeBilgileri = new Uye() { Id = 1, Ad = "Akın", Soyad = "Malkoç", Email = "akin@siteadi.com" };

            return View(uyeBilgileri);
        }
        [HttpPost]
        public IActionResult UyeDuzenle(Uye uye)
        {
            if (ModelState.IsValid)
            {
                // Eğer validasyon kurallarına uygun veri gönderilmişse kaydı güncelle
                return RedirectToAction("UyeListesi");
            }
            return View(uye);
        }
        public IActionResult UyeSil(int? id)
        {
            var uyeBilgileri = new Uye() { Id = 1, Ad = "Akın", Soyad = "Malkoç", Email = "akin@siteadi.com" };

            return View(uyeBilgileri);
        }
        [HttpPost]
        public IActionResult UyeSil(Uye uye)
        {
            // Kaydı sil
            return RedirectToAction("UyeListesi"); // sayfayı listeye yönlendir
        }
    }
}
