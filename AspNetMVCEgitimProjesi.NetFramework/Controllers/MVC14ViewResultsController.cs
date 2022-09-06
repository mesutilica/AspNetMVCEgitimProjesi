using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC14ViewResultsController : Controller
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
            return RedirectToAction("Index"); // ActionaYonlendir metodu tetiklendiğinde FarkliViewDondur isimli actiona sayfayı yönlendir
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
    }
}