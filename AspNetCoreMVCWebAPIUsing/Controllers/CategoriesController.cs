using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCWebAPIUsing.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
