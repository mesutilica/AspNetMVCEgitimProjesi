using AspNetMVCEgitimProjesi.NetCore.Areas.Admin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspNetMVCEgitimProjesi.NetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        DatabaseContext context = new();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string Username, string Password)
        {
            try
            {
                var account = context.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
                if (account == null)
                {
                    ModelState.AddModelError("", "Giriş Başarısız!");
                }
                else
                {
                    var claims = new List<Claim>() // Claim = Hak
                    {
                        new Claim(ClaimTypes.Name, account.Name) // 
                    };
                    var userIdentity = new ClaimsIdentity(claims, "Login"); // Kullanıcıya kimlik çıkartıyoruz

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(claimsPrincipal); // Yukarıda tanımladığımız haklarla sisteme giriş yaptırıyoruz

                    return RedirectToAction("Index", "Default");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(); // Çıkış işlemi yapılıyor

            return RedirectToAction("Index"); // Çıkış yapan kullanıcı tekrar loin e yönlendiriliyor
        }

    }
}
