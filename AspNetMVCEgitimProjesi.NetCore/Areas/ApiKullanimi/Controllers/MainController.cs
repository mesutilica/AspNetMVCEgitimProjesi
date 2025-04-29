using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Areas.ApiKullanimi.Controllers
{
    [Area("Admin")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
