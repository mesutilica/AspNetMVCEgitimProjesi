using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC08PartialController : Controller
    {
        private readonly UyeContext _context;

        public MVC08PartialController(UyeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Uyeler.ToList());
        }
    }
}
