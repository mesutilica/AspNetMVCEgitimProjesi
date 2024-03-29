﻿using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC19CachingController : Controller
    {
        private readonly UyeContext _context;
        private readonly IMemoryCache _memoryCache;
        public MVC19CachingController(IMemoryCache memoryCache, UyeContext context)
        {
            _memoryCache = memoryCache;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Uyeler.ToList();
            if (model is null)
            {
                _context.Uyeler.AddRange(
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
                _context.SaveChanges();
                model = _context.Uyeler.ToList();
            }
            return View(model);
        }
        public IActionResult IndexCache()
        {
            var list = _memoryCache.Get<List<Uye>>("liste");

            if (list is null)
            {
                list = _context.Uyeler.ToList();
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
                _context.Add(uye); // 6. yöntem
                _context.SaveChanges();
                TempData["Uye"] = uye.Ad + " " + uye.Soyad + " İsimli üye kaydı başarıyla gerçekleşti..";
                //_memoryCache.Remove("liste");
                return RedirectToAction("Index");
            }
            return View(uye);
        }
    }
}
