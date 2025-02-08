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
            var urunListesi = new List<Urun>
            {
                new Urun() { Adi = "Oyun Bilgisayarı", Fiyati = 49000, Stok = 5 },
                new Urun() { Adi = "Laptop", Fiyati = 29000, Stok = 7 },
                new Urun() { Adi = "İş İstasyonu", Fiyati = 99000, Stok = 3 }
            };
            ViewData["Urunler"] = urunListesi;
            // 3-TempData : 2 kullanımlık ömrü vardır.
            TempData["UrunBilgi"] = "Toplam " + urunListesi.Count + " Ürün Bulundu..";

            ViewBag.GetVerisi = txtAra;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string txtUrunAdi, string ddlKategori, bool cbOnay, string rbOnay, FormCollection formCollection)
        {
            var urunListesi = new List<Urun>
            {
                new Urun() { Adi = "Oyun Bilgisayarı", Fiyati = 49000, Stok = 5 },
                new Urun() { Adi = "Laptop", Fiyati = 29000, Stok = 7 },
                new Urun() { Adi = "İş İstasyonu", Fiyati = 99000, Stok = 3 }
            };
            ViewData["Urunler"] = urunListesi;

            ViewBag.Baslik1 = "1. Yöntem Parametreyle Veri Yakalama";
            ViewBag.Mesaj1 = "Textbox değeri : " + txtUrunAdi;
            ViewBag.Mesaj2 = "Dropdown değeri : " + ddlKategori;
            ViewBag.Mesaj3 = "cbOnay değeri : " + cbOnay;
            ViewBag.Mesaj3 += " - rbOnay değeri : " + rbOnay;

            ViewBag.Baslik2 = "2. Yöntem FormCollection İle Yakalama";
            ViewBag.Mesaj4 = "Textbox değeri : " + formCollection["txtUrunAdi"];
            ViewBag.Mesaj5 = "Dropdown değeri : " + formCollection["ddlKategori"];
            ViewBag.Mesaj6 = "cbOnay değeri : " + formCollection.GetValues("cbOnay")[0];
            ViewBag.Mesaj6 += "rbOnay değeri : " + formCollection.GetValues("rbOnay")[0];

            ViewBag.Baslik3 = "3. Yöntem Request Form İle Yakalama";
            ViewBag.Mesaj7 = "Textbox değeri : " + Request.Form["txtUrunAdi"];
            ViewBag.Mesaj8 = "Dropdown değeri : " + Request.Form["ddlKategori"];
            ViewBag.Mesaj9 = "cbOnay değeri : " + Request.Form.GetValues("cbOnay")[0];
            ViewBag.Mesaj9 += "rbOnay değeri : " + Request.Form.GetValues("rbOnay")[0];
            ViewBag.Mesaj9 += " -- <hr> txtUrunAdi değeri : " + Request.Form.GetValues("txtUrunAdi")[0];
            ViewBag.Mesaj9 += " -- ddlKategori değeri : " + Request.Form.GetValues("ddlKategori")[0];
            return View();
        }
    }
}