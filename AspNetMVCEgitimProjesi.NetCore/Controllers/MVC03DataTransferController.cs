using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC03DataTransferController : Controller
    {
        // Varsayılan methot türü GET dir.
        public IActionResult Index(string txtAra) // string değişkenin adının txtAra olması ön yüzdeki textbox ın name değeriyle eşleştirilmesi için. Farklı isim verilirse veri yakalanamaz.
        {
            // MVC de temel olarak 3 türde view a veri yollama yapısı var
            // Örneğin veritabanından ürün bilgisini çekip ekrana  yollamak için

            // 1- ViewBag : Tek Kullanımlık Ömrü Var
            ViewBag.UrunKategorisi = "Bilgisayar";
            // 2-Viewdata : Tek Kullanımlık Ömrü Var
            IList<Urun> urunListesi = new List<Urun>
            {
                new Urun() { Adi = "Oyun Bilgisayarı", Fiyati = 49000, Stok = 5 },
                new Urun() { Adi = "Laptop", Fiyati = 29000, Stok = 7 },
                new Urun() { Adi = "İş İstasyonu", Fiyati = 99000, Stok = 3 }
            };
            ViewData["Urunler"] = urunListesi;
            // 3-TempData : 2 Kullanımlık Ömrü Var
            TempData["UrunBilgi"] = "Toplam " + urunListesi.Count + " Ürün Bulundu..";

            ViewBag.GetVerisi = txtAra;
            return View();
        }
        [HttpPost] // Aşağıdaki metot sayfa (View) post edildiğinde çalışır
        public IActionResult Index(string text1, string ddlListe, bool cbOnay, IFormCollection formCollection)
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

            ViewBag.Baslik2 = "2. Yöntem FormCollection İle Yakalama";
            ViewBag.Mesaj4 = "Textbox değeri : " + formCollection["text1"];
            ViewBag.Mesaj5 = "Dropdown değeri : " + formCollection["ddlListe"];
            ViewBag.Mesaj6 = "cbOnay değeri : " + formCollection["cbOnay"][0];
            //ViewBag.Mesaj6 = "cbOnay değeri : " + formCollection.GetValues("cbOnay")[0];

            ViewBag.Baslik3 = "3. Yöntem Request Form İle Yakalama";
            ViewBag.Mesaj7 = "Textbox değeri : " + Request.Form["text1"];
            ViewBag.Mesaj8 = "Dropdown değeri : " + Request.Form["ddlListe"];
            ViewBag.Mesaj9 = "cbOnay değeri : " + Request.Form["cbOnay"][0];
            //ViewBag.Mesaj9 = "cbOnay değeri : " + Request.Form.GetValues("cbOnay")[0];
            //ViewBag.Mesaj9 += " -- <hr> text1 değeri : " + Request.Form.GetValues("text1")[0];
            //ViewBag.Mesaj9 += " -- ddlListe değeri : " + Request.Form.GetValues("ddlListe")[0]; bunlar çalışmıyor
            TempData["Tdata2"] = "Checkbox dan seçilen değer : " + Request.Form["cbOnay"][0];// first() de kullanılabilir //true seçince true,false dönüyor

            //TempData["Tdata"] = "Checkbox dan seçilen değer : " + Request.Form.GetValues("cbOnay")[0];

            return View();
        }

    }
}
