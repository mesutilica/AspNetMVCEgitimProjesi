using AspNetMVCEgitimProjesi.NetFramework.Models;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC05ModelValidationController : Controller
    {
        // GET: MVC11ModelValidation
        public ActionResult Index()
        {
            return View();
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
                return RedirectToAction("UyeListesi");
            }
            if (!ModelState.IsValid) // model kuralları geçersizse
            {
                ViewBag.Uye = "Lütfen gerekli alanları doldurunuz!";
            }
            return View(uye);
        }
    }
}