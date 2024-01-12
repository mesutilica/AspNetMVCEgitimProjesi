using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC14AppSettingController : Controller
    {
        private readonly IConfiguration _configuration;

        public MVC14AppSettingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            TempData["Email"] = _configuration["Email"]; // TempData ile appsettings deki Email bilgisini okuyup view a gönderdik
            TempData["MailSunucu"] = _configuration["MailSunucu"];
            TempData["KullaniciAdi"] = _configuration["MailKullanici:UserName"]; // json daki MailKullanici altındaki Username değerine : ile ulaşıyoruz
            TempData["Sifre"] = _configuration.GetSection("MailKullanici:Password").Value;// GetSection metoduyla da veriyi çekebiliriz
            return View();
        }
    }
}
