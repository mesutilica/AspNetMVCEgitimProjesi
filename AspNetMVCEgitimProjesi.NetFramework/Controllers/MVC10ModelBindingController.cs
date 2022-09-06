using AspNetMVCEgitimProjesi.NetCore.Models;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC10ModelBindingController : Controller
    {
        // GET: MVC10ModelBinding
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Kullanici()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "info@yoneciti.com",
                KullaniciAdi = "murat",
                Sifre = "123456"
            };

            return View(kullanici); // yukardaki kullanici nesnesinin view da model olarak kullanılabilmesi için bu şekilde view a göndermemiz gerekir.
        }
        [HttpPost]
        public ActionResult Kullanici(Kullanici kullanici) // Burada belirttiğimiz kullanici nesnesi view sayfasındaki model kullanan form içerisindeki verileri model binding yöntemiyle yakalıyor.
        {
            return View(kullanici); // Post işleminden sonra metoda parametreyle gelen kullanici nesnesini tekrar ekrana gönder
        }
        public ActionResult Adres()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adres(Adres adres)
        {
            // Projelerde bu noktada yakaladığımız adres nesnesini veritabanına kaydederiz.
            return View(adres);
        }
        public ActionResult UyeSayfasi()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "info@yoneciti.com",
                KullaniciAdi = "murat",
                Sifre = "123456"
            };
            //kullanici.Sifre = "112365";
            UyeSayfasiViewModel model = new UyeSayfasiViewModel()
            {
                Kullanici = kullanici,
                Adres = new Adres { Ilce = "Ataşehir", Sehir = "İstanbul", AcikAdres = "Menekşe Sokak No:18" }
            };
            //model.Adres = new Adres { Ilce = "Ataşehir", Sehir = "İstanbul", AcikAdres = "Menekşe Sokak No:18" };
            return View(model);
        }
    }
}