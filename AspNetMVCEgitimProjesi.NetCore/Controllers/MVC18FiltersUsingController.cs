using AspNetMVCEgitimProjesi.NetCore.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC18FiltersUsingController : Controller
    {
        [UserControl]
        public IActionResult Index()
        {
            ViewBag.Kullanici = HttpContext.Session.GetString("UserGuid");
            return View();
        }
    }
}
