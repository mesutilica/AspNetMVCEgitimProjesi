using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC13StringFormatController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MusteriNo = string.Format("M{0:D6}", 1);
            ViewBag.SaticiNo = string.Format("S{0:D6}", 218);
            return View();
        }
    }
}
