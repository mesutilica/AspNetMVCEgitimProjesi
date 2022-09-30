using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC16FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormFile? Image)
        {
            if (Image is not null)
            {
                string directory = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                using var stream = new FileStream(directory, FileMode.Create); // Buradaki using ifadesi stream isimli değişkenin işinin bittikten sonra bellekten atılmasını sağlar
                Image.CopyTo(stream); // resmi asenkron olarak yükledik
                TempData["Resim"] = Image.FileName;
            }
            return View();
        }
    }
}
