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
            ViewData["UrunAdi"] = "Everbook Laptop";
            // 3-TempData : 2 kullanımlık ömrü vardır.
            TempData["UrunFiyati"] = 18.000;

            ViewBag.ArananKelime = txtAra;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string text1, string ddlListe, bool cbOnay, FormCollection formCollection)
        {
            ViewBag.Baslik1 = "1. Yöntem Parametreyle Veri Yakalama";
            ViewBag.Mesaj1 = "Textbox değeri : " + text1;
            ViewBag.Mesaj2 = "Dropdown değeri : " + ddlListe;
            ViewBag.Mesaj3 = "cbOnay değeri : " + cbOnay;

            ViewBag.Baslik2 = "2. Yöntem FormCollection İle Yakalama";
            ViewBag.Mesaj4 = "Textbox değeri : " + formCollection["text1"];
            ViewBag.Mesaj5 = "Dropdown değeri : " + formCollection["ddlListe"];
            ViewBag.Mesaj6 = "cbOnay değeri : " + formCollection.GetValues("cbOnay")[0];

            ViewBag.Baslik3 = "3. Yöntem Request Form İle Yakalama";
            ViewBag.Mesaj7 = "Textbox değeri : " + Request.Form["text1"];
            ViewBag.Mesaj8 = "Dropdown değeri : " + Request.Form["ddlListe"];
            ViewBag.Mesaj9 = "cbOnay değeri : " + Request.Form.GetValues("cbOnay")[0];
            ViewBag.Mesaj9 += " -- <hr> text1 değeri : " + Request.Form.GetValues("text1")[0];
            ViewBag.Mesaj9 += " -- ddlListe değeri : " + Request.Form.GetValues("ddlListe")[0];
            return View();
        }
    }
}