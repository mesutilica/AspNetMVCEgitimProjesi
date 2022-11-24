using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC16ViewComponentUsingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
