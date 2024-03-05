using AspNetCore.Entities;
using AspNetCore.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCWebAPIUsing.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres;
        private static readonly string Username = "test";
        private static readonly string Password = "test@123";
        public AccountController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiAdres = "https://localhost:7116/Api/Auth/";
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult JsLogin()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserLoginModel userLoginModel)
        {
            try
            {
                //_httpClient.DefaultRequestHeaders.Authorization.Parameter.Insert(0,"test");
                var response = await _httpClient.PostAsJsonAsync(_apiAdres + "Login", userLoginModel);
                if (response.IsSuccessStatusCode)
                {
                    Token jwt = await response.Content.ReadFromJsonAsync<Token>();
                    if (jwt is not null)
                    {
                        HttpContext.Session.SetString("userToken", jwt.AccessToken);
                    }
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Giriş Başarısız!");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(User appUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //_httpClient.DefaultRequestHeaders.Authorization.Parameter.Insert(0,"test");
                    appUser.CreateDate = DateTime.Now;
                    var response = await _httpClient.PostAsJsonAsync(_apiAdres + "CreateAppUser", appUser);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                    ModelState.AddModelError("", "Kayıt Başarısız!");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(appUser);
        }
    }
}
