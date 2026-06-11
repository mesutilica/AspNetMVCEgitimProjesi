using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.ViewComponents
{
    public class Uyeler : ViewComponent
    {
        private readonly UyeContext _context;

        public Uyeler(UyeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(string secili)
        {
            ViewBag.Secili = secili;
            return View();
        }
    }
}
