using AspNetMVCEgitimProjesi.NetFramework.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC08ViewResultsController : Controller
    {
        // GET: MVC14ViewResults
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FarkliViewDondur()
        {
            return View("Index");
        }
        public ActionResult Yonlendir(string arananDeger)
        {
            // Bir action içerisinde farklı bir sayfaya yönlendirme yapabiliriz
            //return Redirect("/Home"); // Redirect ile sayfa yönlendirme genelde verilerle ilgili bir işlemden sonra lazım olur
            //return Redirect($"/Home/Index?kelime={arananDeger}"); // ?kelime=telefon kısmı QueryString olarak geçer ve gittiği sayfada adres çubuğu üzerinden bu veriye ulaşıp sorgulama yapabiliriz.
            return Redirect("https://www.google.com.tr/"); // Redirect metoduyla başka bir siteye de yönlendirme yapabiliriz.
        }
        public ActionResult ActionaYonlendir()
        {
            //return RedirectToAction("Index"); // ActionaYonlendir metodu tetiklendiğinde FarkliViewDondur isimli actiona sayfayı yönlendir
            //return RedirectToAction("Yonlendir");
            return RedirectToAction("UyeListesi", "MVC05ModelValidation"); // controller ve action u belirtebiliriz
        }
        public RedirectToRouteResult RouteYonlendir()
        {
            return RedirectToRoute("Default", new { controller = "Home", action = "Index", id = 18 });
        }
        public PartialViewResult KategorileriGetirPartial() // Geriye PartialView döndüren action
        {
            return PartialView("_KategorilerPartial"); // Geriye döndermek istediğimiz partial ismini verebiliriz
        }
        public PartialViewResult KategorileriModelleGetirPartial() // Geriye PartialView döndüren action
        {
            // Model için kullanılacak listeyi burada veritabanından çekeriz
            List<string> kategoriler = new List<string>()
            {
                "Telefon", "Bilgisayar", "Monitör", "Klavye", "Laptop"
            };
            return PartialView("_KategorilerPartialModelKullanimi", kategoriler); // Geriye döndermek istediğimiz partial ismini verebiliriz
        }
        public FileStreamResult MetinDosyasiIndir()
        {
            string metin = "FileStreamResult ile metin dosyası indirme";

            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(metin);
            memory.Write(bytes, 0, bytes.Length);
            memory.Position = 0;
            FileStreamResult result = new FileStreamResult(memory, "text/plain");
            result.FileDownloadName = "metin.txt";

            return result;
        }
        public JavaScriptResult JsResult()
        {
            return JavaScript("alert('JavaScriptResult')");
        }
        public JsonResult JsonResult()
        {
            var kullanici = new Kullanici()
            {
                Ad = "Ali",
                Soyad = "Çakmaktaş",
                KullaniciAdi = "acakmak",
                Email = "ali@cakmaktas.com"
            };
            return Json(kullanici, JsonRequestBehavior.AllowGet);
        }
        public ContentResult XmlContentResult()
        {
            var xml = @"
                <urunler>
                    <urun>
                        <Id>1</Id>
                        <UrunAdi>Klavye</UrunAdi>
                        <Fiyati>199</Fiyati>
                        <Stok>3</Stok>
                        <Kategori>Bilgisayar</Kategori>
                    </urun>
                    <urun>
                        <Id>2</Id>
                        <UrunAdi>Mouse</UrunAdi>
                        <Fiyati>99</Fiyati>
                        <Stok>5</Stok>
                        <Kategori>Bilgisayar</Kategori>
                    </urun>
                </urunler>
            ";

            return Content(xml, "application/xml");
        }
    }
}