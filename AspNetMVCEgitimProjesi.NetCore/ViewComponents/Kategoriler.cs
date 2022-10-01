using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.ViewComponents
{
    public class Kategoriler : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
