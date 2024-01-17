using AspNetMVCEgitimProjesi.NetCore.Filters;
using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC15FiltersUsingController : Controller
    {
        private readonly UyeContext _context;

        public MVC15FiltersUsingController(UyeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Kullanici = HttpContext.Session.GetString("UserGuid");
            return View();
        }
        [UserControl]
        public ActionResult FiltreKullanimi()
        {
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<ActionResult> UyeGuncelleAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uye = await _context.Uyeler.FindAsync(id);
            if (uye == null)
            {
                return NotFound();
            }
            return View(uye);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UyeGuncelle(Uye uye)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(uye).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uye);
        }
        public ActionResult Login()
        {
            return View();
        }
        //[HandleError]
        //[HandleError(ExceptionType = typeof(NullReferenceException), View = "~/Views/Error/NullReference.cshtml")]
        [OutputCache(Duration = 10)] // Keşleme attribute ü
        public ActionResult HataYakalama()
        {
            string msg = null;
            ViewBag.Message = msg.Length;
            return View();
        }
    }
}
