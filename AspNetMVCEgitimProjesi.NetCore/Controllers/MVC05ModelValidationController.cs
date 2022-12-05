using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                //context.Uyes.Add(uye); // 1. yöntem
                //context.Add<Uye>(uye); // 2. yöntem
                //context.Entry<Uye>(uye).State = EntityState.Added; // 3. yöntem
                //context.Entry(uye).State = EntityState.Added; // 4. yöntem
                //context.Attach<Uye>(uye); // 5. yöntem
                context.Add(uye); // 6. yöntem
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
            //var uye = context.Uyes.Find(id);
            //var uye = context.Uyes.Where(b => b.Id == id).FirstOrDefault();
            //var uye = context.Uyes.Where(b => b.Id == id).SingleOrDefault();
            //var uye = context.Uyes.FirstOrDefault(b => b.Id == id);
            var uye = context.Uyes.SingleOrDefault(b => b.Id == id);

            return View(uye);
        }
        [HttpPost]
        public IActionResult UyeDuzenle(Uye uye)
        {
            if (ModelState.IsValid)
            {
                // Eğer validasyon kurallarına uygun veri gönderilmişse kaydı güncelle
                // context.Update(uye);
                // context.Uyes.Update(uye);
                // context.Attach<Uye>(uye).State = EntityState.Modified;
                // context.Entry(uye).State = EntityState.Modified;
                // context.Entry<Uye>(uye).State = EntityState.Modified;
                context.Entry(uye).State = EntityState.Modified;
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
            // context.Uyes.Remove(uye);
            // context.Attach<Uye>(uye).State = EntityState.Deleted;
            // context.Entry(uye).State = EntityState.Deleted;
            // context.Entry<Uye>(uye).State = EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("UyeListesi"); // sayfayı listeye yönlendir
        }
    }
}
