using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.ViewComponents
{
    public class Uyeler : ViewComponent
    {
        public IViewComponentResult Invoke(string secili)
        {
            ViewBag.Secili = secili;
            return View();
        }
    }
}
