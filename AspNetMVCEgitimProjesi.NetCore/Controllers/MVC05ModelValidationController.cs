using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC05ModelValidationController : Controller
    {
        public IActionResult Index()
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
                // kayıt ekle
            }
            else
            {
                ModelState.AddModelError("", "Lütfen Tüm Zorunlu Alanları Doldurunuz!");
            }
            return View(uye);
        }
    }
}
