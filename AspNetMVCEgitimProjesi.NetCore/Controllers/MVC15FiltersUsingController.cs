using AspNetMVCEgitimProjesi.NetCore.Filters;
using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        public async Task<ActionResult> UyeGuncelle(int? id)
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
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> LoginAsync(Uye uye)
        {
            try
            {
                var kullanici = await _context.Uyeler.FirstOrDefaultAsync(u => u.Email == uye.Email && u.Sifre == uye.Sifre);
                if (kullanici != null) // eğer girilen bilgilerle eşleşen kullanıcı varsa
                {
                    var haklar = new List<Claim>() // kullanıcı hakları tanımladık
                    {
                        new(ClaimTypes.Email, kullanici.Email), // claim = hak(kullanıcıya tanımlalan haklar)
                        new(ClaimTypes.Role, "Admin")
                    };
                    var kullaniciKimligi = new ClaimsIdentity(haklar, "Login"); // kullanıcı için bir kimlik oluşturduk
                    ClaimsPrincipal claimsPrincipal = new(kullaniciKimligi);
                    await HttpContext.SignInAsync(claimsPrincipal); // yukardaki yetkilerle sisteme giriş yaptık
                    if (!string.IsNullOrEmpty(HttpContext.Request.Query["ReturnUrl"])) // eğer adres çubuğunda ReturnUrl diye bir değer varsa
                    {
                        return Redirect(HttpContext.Request.Query["ReturnUrl"]); // oturum açıldıktan sonra kullanıcıyı kaldığı yere dönürmek için returnurl deki adrese yönlendir
                    }
                    return RedirectToAction("Index");
                }
                else TempData["Message"] = "<div class='alert alert-danger'>Giriş Başarısız!</div>";
            }
            catch (Exception)
            {
                TempData["Message"] = "<div class='alert alert-danger'>Hata Oluştu!</div>";
            }
            return View(uye);
        }
        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
        //[HandleError]
        //[HandleError(ExceptionType = typeof(NullReferenceException), View = "~/Views/Error/NullReference.cshtml")]
        [OutputCache(Duration = 10)] // OutputCache filter
        public ActionResult HataYakalama()
        {
            string msg = null;
            ViewBag.Message = msg.Length;
            return View();
        }
    }
}
