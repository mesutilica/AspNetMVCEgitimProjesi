using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC03PostBackController : Controller
    {
        [HttpGet]
        public IActionResult Index(string kelime)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string kelime, string txtad)
        {
            Debug.WriteLine(txtad); // start > output
            return View();
        }
    }
}
