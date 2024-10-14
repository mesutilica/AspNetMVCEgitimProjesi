using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
