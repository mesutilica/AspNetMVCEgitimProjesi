using AspNetMVCEgitimProjesi.NetFramework.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC03DataTransferController : Controller
    {
        // GET: MVC03DataTransfer
        public ActionResult Index(string txtAra)
        {
            // 3 Farklı Yöntemle Controllerdan View a Basit Veriler Gönderebiliriz

            // 1-ViewBag : Tek kullanımlık ömrü vardır.
            ViewBag.UrunKategorisi = "Bilgisayar"; // Burada ViewBag ismi standart olarak yazılır sonrasında . deyip dilediğimiz değişken adını yazabiliriz.
            // 2-ViewData : Tek kullanımlık ömrü vardır.
            IList<Urun> urunListesi = new List<Urun>
            {
                new Urun() { Adi = "Oyun Bilgisayarı", Fiyati = 49000, Stok = 5 },
                new Urun() { Adi = "Laptop", Fiyati = 29000, Stok = 7 },
                new Urun() { Adi = "İş İstasyonu", Fiyati = 99000, Stok = 3 }
            };
            ViewData["Urunler"] = urunListesi;
            // 3-TempData : 2 kullanımlık ömrü vardır.
            TempData["UrunBilgi"] = "Toplam " + urunListesi.Count + " Ürün Bulundu..";

            ViewBag.ArananKelime = txtAra;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string text1, string ddlListe, bool cbOnay, string rbOnay, FormCollection formCollection)
        {
            IList<Urun> urunListesi = new List<Urun>
            {
                new Urun() { Adi = "Oyun Bilgisayarı", Fiyati = 49000, Stok = 5 },
                new Urun() { Adi = "Laptop", Fiyati = 29000, Stok = 7 },
                new Urun() { Adi = "İş İstasyonu", Fiyati = 99000, Stok = 3 }
            };
            ViewData["Urunler"] = urunListesi;

            ViewBag.Baslik1 = "1. Yöntem Parametreyle Veri Yakalama";
            ViewBag.Mesaj1 = "Textbox değeri : " + text1;
            ViewBag.Mesaj2 = "Dropdown değeri : " + ddlListe;
            ViewBag.Mesaj3 = "cbOnay değeri : " + cbOnay;
            ViewBag.Mesaj3 += " - rbOnay değeri : " + rbOnay;

            ViewBag.Baslik2 = "2. Yöntem FormCollection İle Yakalama";
            ViewBag.Mesaj4 = "Textbox değeri : " + formCollection["text1"];
            ViewBag.Mesaj5 = "Dropdown değeri : " + formCollection["ddlListe"];
            ViewBag.Mesaj6 = "cbOnay değeri : " + formCollection.GetValues("cbOnay")[0];
            ViewBag.Mesaj6 += "rbOnay değeri : " + formCollection.GetValues("rbOnay")[0];

            ViewBag.Baslik3 = "3. Yöntem Request Form İle Yakalama";
            ViewBag.Mesaj7 = "Textbox değeri : " + Request.Form["text1"];
            ViewBag.Mesaj8 = "Dropdown değeri : " + Request.Form["ddlListe"];
            ViewBag.Mesaj9 = "cbOnay değeri : " + Request.Form.GetValues("cbOnay")[0];
            ViewBag.Mesaj9 += "rbOnay değeri : " + Request.Form.GetValues("rbOnay")[0];
            ViewBag.Mesaj9 += " -- <hr> text1 değeri : " + Request.Form.GetValues("text1")[0];
            ViewBag.Mesaj9 += " -- ddlListe değeri : " + Request.Form.GetValues("ddlListe")[0];
            return View();
        }
    }
}