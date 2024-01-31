using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            return View();
        }
    }
}
