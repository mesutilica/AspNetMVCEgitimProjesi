using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC18ViewComponentUsingController : Controller
    {
        private readonly UyeContext _context;

        public MVC18ViewComponentUsingController(UyeContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Uyeler.ToListAsync());
        }
    }
}
