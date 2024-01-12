using AspNetMVCEgitimProjesi.NetCore.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC18FluentValidationController : Controller
    {
        private IValidator<Kullanici> _validator;

        public MVC18FluentValidationController(IValidator<Kullanici> validator)
        {
            _validator = validator;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Kullanici kullanici)
        {
            FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(kullanici);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.Remove(error.PropertyName); // standart hata mesajlarını silmek için
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage); // FluentValidation hatalarını eklemek için
                    ModelState.AddModelError("", error.ErrorMessage); // hataları üst kısımda göstermek için
                }
                return View("Index", kullanici);
            }

            // Eğer isvalid ise burada kaydı gerçekleştir

            TempData["mesaj"] = "Kayıt Başarılı";
            return RedirectToAction("Index");
        }
    }
}
