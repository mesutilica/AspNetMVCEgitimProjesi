using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC17ViewComponentUsingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
