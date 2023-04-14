using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.ViewComponents
{
    public class Kategoriler : ViewComponent
    {
        public IViewComponentResult Invoke(string secili)
        {
            ViewBag.Secili = secili;
            return View();
        }
    }
}
