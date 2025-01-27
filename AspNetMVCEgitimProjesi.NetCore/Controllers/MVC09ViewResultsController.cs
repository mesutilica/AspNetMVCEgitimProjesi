using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC09ViewResultsController : Controller
    {
        private readonly UyeContext _context;

        public MVC09ViewResultsController(UyeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FarkliViewDondur()
        {
            return View("Index");
        }
        public IActionResult Yonlendir(string kelime)
        {
            // Bir action içerisinde farklı bir sayfaya yönlendirme yapabiliriz
            //return Redirect("/Home"); // Redirect ile sayfa yönlendirme genelde verilerle ilgili bir işlemden sonra lazım olur
            //return Redirect($"/Home/Index?kelime={arananDeger}"); // ?kelime=telefon kısmı QueryString olarak geçer ve gittiği sayfada adres çubuğu üzerinden bu veriye ulaşıp sorgulama yapabiliriz.
            return Redirect("https://www.google.com.tr/"); // Redirect metoduyla başka bir siteye de yönlendirme yapabiliriz.
        }
        public IActionResult ActionaYonlendir()
        {
            //return RedirectToAction("Index");
            //return RedirectToAction("Yonlendir");
            return RedirectToAction("Index", "Home"); // controller ve action u belirtebiliriz
        }
        public RedirectToRouteResult RouteYonlendir()
        {
            return RedirectToRoute("Default", new { controller = "Home", action = "Index", id = 18 });
        }
        public PartialViewResult KategorileriGetirPartial() // Geriye PartialView döndüren action
        {
            return PartialView("_KategorilerPartial"); // Geriye döndermek istediğimiz partial ismini verebiliriz
        }
        public JsonResult JsonDondur()
        {
            var kullanicilar = _context.Uyeler.ToList();
            return Json(kullanicilar);
        }
        public ContentResult XmlContentResult()
        {
            var kullanicilar = _context.Uyeler.ToList();
            var xml = "<kullanicilar>";
            foreach (var item in kullanicilar)
            {
                xml += $@"<kullanici>
                        <Id>{item.Id}</Id>
                        <Ad>{item.Ad}</Ad>
                        <Soyad>{item.Soyad}</Soyad>
                        <KullaniciAdi>{item.TcKimlikNo}</KullaniciAdi>
                        <Email>{item.DogumTarihi}</Email>
                    </kullanici>";
            }
            xml += "</kullanicilar>";
            return Content(xml, "application/xml");
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
    }
}
