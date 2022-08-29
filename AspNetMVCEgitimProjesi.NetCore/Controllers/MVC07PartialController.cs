using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC07PartialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
