using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCWebAPIUsing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DefaultController : Controller
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
