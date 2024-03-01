using AspNetCore.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AspNetCoreMVCProjesi.Controllers
{
    public class LoginController : Controller
    {
        private readonly DatabaseContext _databaseContext; // S.O.L.I.D Prensipleri - CleanCode

        public LoginController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost] // Post
        public async Task<IActionResult> IndexAsync(string email, string password)
        {
            try
            {
                var kullanici = await _databaseContext.Users.FirstOrDefaultAsync(k => k.Email == email && k.Password == password && k.IsActive);
                if (kullanici == null) TempData["Mesaj"] = "Giriş Başarısız!";
                else
                {
                    var haklar = new List<Claim>() // Claim = Hak
                    {
                        new Claim(ClaimTypes.Email, kullanici.Email) // kullanıcıya hak tanımladık
                    };
                    var kullaniciKimligi = new ClaimsIdentity(haklar, "Login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(kullaniciKimligi);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (kullanici.IsAdmin) return Redirect("/Admin");
                    else return Redirect("/Home");
                }
            }
            catch (Exception)
            {
                TempData["Mesaj"] = "Hata Oluştu!";
            }
            return View();
        }
        [Route("Logout")] // Aşağıdaki action url si Login/Logout yerine sadece Logout olsun
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
