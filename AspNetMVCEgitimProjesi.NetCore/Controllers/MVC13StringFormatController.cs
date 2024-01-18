using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC13StringFormatController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Data = string.Format("M{0:D6}", 1);
            ViewBag.Data2 = string.Format("M{0:D6}", 218);
            return View();
        }
    }
}
