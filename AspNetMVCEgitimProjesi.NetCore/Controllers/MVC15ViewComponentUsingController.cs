using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC15ViewComponentUsingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
