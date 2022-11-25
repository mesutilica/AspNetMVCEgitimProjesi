using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC03DataTransferController : Controller
    {
        // GET: MVC08DataTransfer
        public ActionResult Index(string txtAra)
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
        [HttpPost]
        public ActionResult Index(string text1, string ddlListe, bool cbOnay, FormCollection keyValuePairs)
        {
            // 1. Yöntem parametrelerden gelen veriler;

            ViewBag.Mesaj = "Textboxdan gelen veri : " + text1;
            ViewBag.MesajListe = "liste den seçilen değer : " + ddlListe;
            TempData["Tdata"] = "Checkbox dan seçilen değer : " + cbOnay;

            // 2. Yöntem Request Form ile verileri yakalama

            ViewBag.Mesaj2 = "Textboxdan gelen veri : " + Request.Form["text1"];
            ViewBag.MesajListe2 = "liste den seçilen değer : " + Request.Form["ddlListe"];
            //TempData["Tdata"] = "Checkbox dan seçilen değer : " + Request.Form["cbOnay"][0];// first() de kullanılabilir //true seçince true,false dönüyor
            TempData["Tdata2"] = "Checkbox dan seçilen değer : " + Request.Form.GetValues("cbOnay")[0];

            // 3. Yöntem FormCollection Kullanarak

            ViewBag.Mesaj3 = "keyValuePairs Textboxdan gelen veri : " + keyValuePairs["text1"];
            ViewBag.MesajListe3 = "keyValuePairs liste den seçilen değer : " + keyValuePairs["ddlListe"];
            TempData["Tdata3"] = "keyValuePairs Checkbox dan seçilen değer : " + keyValuePairs.GetValues("cbOnay")[0];
            return View();
        }
    }
}