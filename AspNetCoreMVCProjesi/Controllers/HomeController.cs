using AspNetCoreMVCProjesi.Data;
using AspNetCoreMVCProjesi.Entities;
using AspNetCoreMVCProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AspNetCoreMVCProjesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context; // Buradaki gibi birden çok DI işlemi varsa _context e sağ tıklayıp Quick actions and .. menüsüne tıklayıp açılan menüden Add parameters to.. ile başlayan menüye tıkladığımızda var olan constructor u bozmadan _context i de ekler.
        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomePageViewModel model = new HomePageViewModel();
            model.Sliders = await _context.Sliders.ToListAsync();
            model.Products = await _context.Products.Take(6).ToListAsync();
            return View(model);
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ContactAsync(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Contacts.AddAsync(contact);
                    var sonuc = await _context.SaveChangesAsync();
                    if (sonuc > 0)
                    {
                        TempData["Mesaj"] = "<div class='alert alert-success'>Mesajınız İletilmiştir. Teşekkür Ederiz..</div>";
                        return RedirectToAction("Contact");
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Hata Oluştu! Mesaj Gönderilemedi!");
                }
            }
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}