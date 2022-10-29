using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC19AppSettingController : Controller
    {
        private readonly IConfiguration _configuration;

        public MVC19AppSettingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            TempData["Email"] = _configuration["Email"]; // TempData ile appsettings deki Email bilgisini okuyup view a gönderdik
            TempData["MailSunucu"] = _configuration["MailSunucu"];
            TempData["UserName"] = _configuration["MailKullanici:UserName"];
            TempData["Password"] = _configuration.GetSection("MailKullanici:Password").Value;
            return View();
        }
    }
}
