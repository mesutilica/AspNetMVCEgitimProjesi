using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC05ModelValidationController : Controller
    {
        UyeContext context = new UyeContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UyeListesi()
        {
            return View(context.Uyes.ToList()); // Ekrana modeli view içerisinde gönderebiliyoruz
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
                context.Uyes.Add(uye);
                context.SaveChanges();
                TempData["Uye"] = uye.Ad + " " + uye.Soyad + " İsimli üye kaydı başarıyla gerçekleşti..";
                return RedirectToAction("UyeListesi");
            }
            if (!ModelState.IsValid) // model kuralları geçersizse
            {
                ViewBag.Uye = "Lütfen gerekli alanları doldurunuz!";
            }
            return View(uye);
        }
        public IActionResult UyeDuzenle(int? id) // Üye düzenle sayfasına adres çubuğundaki Route üzerinden id bilgisi gönderilir ve bu id ile eşleşen kayıt veritabanından çekilerek ekrana gönderilir.
        {
            var uye = context.Uyes.Find(id);

            return View(uye);
        }
        [HttpPost]
        public IActionResult UyeDuzenle(Uye uye)
        {
            if (ModelState.IsValid)
            {
                // Eğer validasyon kurallarına uygun veri gönderilmişse kaydı güncelle
                context.Update(uye);
                context.SaveChanges();
                return RedirectToAction("UyeListesi");
            }
            return View(uye);
        }
        public IActionResult UyeSil(int? id)
        {
            var uye = context.Uyes.Find(id);

            return View(uye);
        }
        [HttpPost]
        public IActionResult UyeSil(Uye uye)
        {
            // Kaydı sil
            context.Remove(uye);
            context.SaveChanges();
            return RedirectToAction("UyeListesi"); // sayfayı listeye yönlendir
        }
    }
}
