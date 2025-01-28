using AspNetMVCEgitimProjesi.NetFramework.Models;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC09ViewResultsController : Controller
    {
        private UyeContext context = new UyeContext();
        // GET: MVC14ViewResults
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FarkliViewDondur()
        {
            return View("Index");
        }
        public ActionResult Yonlendir(string kelime)
        {
            // Bir action içerisinde farklı bir sayfaya yönlendirme yapabiliriz
            //return Redirect("/Home"); // Redirect ile sayfa yönlendirme genelde verilerle ilgili bir işlemden sonra lazım olur
            //return Redirect($"/Home/Index?kelime={arananDeger}"); // ?kelime=telefon kısmı QueryString olarak geçer ve gittiği sayfada adres çubuğu üzerinden bu veriye ulaşıp sorgulama yapabiliriz.
            return Redirect("https://www.google.com.tr/"); // Redirect metoduyla başka bir siteye de yönlendirme yapabiliriz.
        }
        public ActionResult ActionaYonlendir()
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
        public PartialViewResult PartialdaModelKullanimi() // Geriye PartialView döndüren action
        {
            // Model için kullanılacak listeyi burada veritabanından çekeriz
            var kullanicilar = context.Uyeler.ToList();
            return PartialView("_PartialModelKullanimi", kullanicilar); // Geriye döndermek istediğimiz partial ismini verebiliriz
        }
        public ActionResult JsResult()
        {
            return JavaScript("console.log('JavaScriptResult')");
        }
        public JsonResult JsonResult()
        {
            var kullanicilar = context.Uyeler.ToList();
            return Json(kullanicilar, JsonRequestBehavior.AllowGet);
        }
        public ContentResult XmlContentResult()
        {
            var kullanicilar = context.Uyeler.ToList();
            var xml = "<kullanicilar>";
            foreach (var item in kullanicilar)
            {
                xml += $@"<kullanici>
                        <Id>{item.Id}</Id>
                        <Ad>{item.Ad}</Ad>
                        <Soyad>{item.Soyad}</Soyad>
                        <KullaniciAdi>{item.KullaniciAdi}</KullaniciAdi>
                        <Email>{item.DogumTarihi}</Email>
                    </kullanici>";
            }
            xml += "</kullanicilar>";

            return Content(xml, "application/xml");
        }
        public FileStreamResult MetinDosyasiIndir()
        {
            string metin = "FileStreamResult ile metin dosyası indirme"; // indirilecek dosya içeriği
            var memory = new System.IO.MemoryStream();
            var bytes = System.Text.Encoding.UTF8.GetBytes(metin);
            memory.Write(bytes, 0, bytes.Length);
            memory.Position = 0;
            var result = new FileStreamResult(memory, "text/plain");
            result.FileDownloadName = "metin.txt";
            return result;
        }
    }
}