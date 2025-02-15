using AspNetMVCEgitimProjesi.NetFramework.Models;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC05ModelValidationController : Controller
    {
        // GET: MVC05ModelValidation
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