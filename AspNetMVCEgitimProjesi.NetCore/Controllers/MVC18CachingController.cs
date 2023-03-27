using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC18CachingController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        List<string> list = new List<string>();
        public MVC18CachingController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            list = _memoryCache.Get<List<string>>("list");

            if (list is null)
            {
                list = new()
                {
                    "Elektronik",
                    "Bilgisayar",
                    "Telefon",
                    "Monitör"
                };
                //Thread.Sleep(5000);
                _memoryCache.Set("list", list, TimeSpan.FromMinutes(1));
            }
            
            return View(list);
        }
        public IActionResult Ekle()
        {
            string yeni = "Yeni Elemean " + list.Count;
            list.Add(yeni);
            TempData["EklenenEleman"] = yeni;
            return RedirectToAction("Index");
        }
    }
}
