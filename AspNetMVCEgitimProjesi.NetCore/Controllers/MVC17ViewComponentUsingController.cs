using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC17ViewComponentUsingController : Controller
    {
        private readonly UyeContext _context;

        public MVC17ViewComponentUsingController(UyeContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Uyeler.ToListAsync());
        }
    }
}
