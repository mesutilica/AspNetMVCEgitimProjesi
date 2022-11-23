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
            ViewData["UrunAdi"] = "Acer Monitör";
            // 3-TempData : 2 Kullanımlık Ömrü Var
            TempData["UrunFiyati"] = 35.18;

            ViewBag.GetVerisi = txtAra;
            return View();
        }
        [HttpPost] // Aşağıdaki metot sayfa (View) post edildiğinde çalışır
        public IActionResult Index(string text1, string ddlListe, bool cbOnay, IFormCollection keyValuePairs)
        {
            // 1. Yöntem parametrelerden gelen veriler;
            /**/
            ViewBag.Mesaj = "Textboxdan gelen veri : " + text1;
            ViewBag.MesajListe = "liste den seçilen değer : " + ddlListe;
            TempData["Tdata"] = "Checkbox dan seçilen değer : " + cbOnay;

            // 2. Yöntem Request Form ile verileri yakalama

            ViewBag.Mesaj2 = "Textboxdan gelen veri : " + Request.Form["text1"];
            ViewBag.MesajListe2 = "liste den seçilen değer : " + Request.Form["ddlListe"];
            TempData["Tdata2"] = "Checkbox dan seçilen değer : " + Request.Form["cbOnay"][0];// first() de kullanılabilir //true seçince true,false dönüyor

            //TempData["Tdata"] = "Checkbox dan seçilen değer : " + Request.Form.GetValues("cbOnay")[0];

            // 3. Yöntem IFormCollection Kullanarak

            ViewBag.Mesaj3 = "keyValuePairs Textboxdan gelen veri : " + keyValuePairs["text1"];
            ViewBag.MesajListe3 = "keyValuePairs liste den seçilen değer : " + keyValuePairs["ddlListe"];
            TempData["Tdata3"] = "keyValuePairs Checkbox dan seçilen değer : " + keyValuePairs["cbOnay"][0];
            return View();
        }

    }
}
