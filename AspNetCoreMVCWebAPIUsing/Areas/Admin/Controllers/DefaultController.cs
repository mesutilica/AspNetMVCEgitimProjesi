using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCWebAPIUsing.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
