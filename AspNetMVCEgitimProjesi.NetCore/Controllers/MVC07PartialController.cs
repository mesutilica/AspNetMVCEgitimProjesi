using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC07PartialController : Controller
    {
        public IActionResult Index()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "info@yoneciti.com",
                KullaniciAdi = "murat",
                Sifre = "123456"
            };
            return View(kullanici);
        }
    }
}
