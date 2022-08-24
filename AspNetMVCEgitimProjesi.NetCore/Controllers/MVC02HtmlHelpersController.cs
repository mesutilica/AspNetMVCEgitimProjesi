using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC02HtmlHelpersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
