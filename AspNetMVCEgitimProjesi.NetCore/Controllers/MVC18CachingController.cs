using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC18CachingController : Controller
    {
        UyeContext context = new UyeContext();
        private readonly IMemoryCache _memoryCache;
        public MVC18CachingController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            var model = context.Uyes.ToList();
            if (model is null)
            {
                context.Uyes.AddRange(
                    new Uye
                    {
                        Ad = "Alp",
                        KullaniciAdi = "alp",
                        Sifre = "123"
                    },
                    new Uye
                    {
                        Ad = "Ali",
                        KullaniciAdi = "ali",
                        Sifre = "456"
                    },
                    new Uye
                    {
                        Ad = "Murat",
                        KullaniciAdi = "Murat",
                        Sifre = "789"
                    }
                );
                context.SaveChanges();
                model = context.Uyes.ToList();
            }
            return View(model);
        }
        public IActionResult IndexCache()
        {
            var list = _memoryCache.Get<List<Uye>>("liste");

            if (list is null)
            {
                list = context.Uyes.ToList();
                //Thread.Sleep(5000);
                _memoryCache.Set("liste", list, TimeSpan.FromSeconds(18));
            }
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Uye uye)
        {
            if (ModelState.IsValid) // Eğer modeldeki validasyon kurallarına uyulmuşsa, tersi için !ModelState.IsValid
            {
                context.Add(uye); // 6. yöntem
                context.SaveChanges();
                TempData["Uye"] = uye.Ad + " " + uye.Soyad + " İsimli üye kaydı başarıyla gerçekleşti..";
                //_memoryCache.Remove("liste");
                return RedirectToAction("Index");
            }
            return View(uye);
        }
    }
}
