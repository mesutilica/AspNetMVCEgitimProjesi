using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC09ViewToControllerDataController : Controller
    {
        // Varsayılan methot türü GET dir.
        public IActionResult Index(string txtAra) // string değişkenin adının txtAra olması ön yüzdeki textbox ın name değeriyle eşleştirilmesi için. Farklı isim verilirse veri yakalanamaz.
        {
            ViewBag.GetVerisi = txtAra;
            return View();
        }
        [HttpPost] // Aşağıdaki metot sayfa (View) post edildiğinde çalışır
        public IActionResult Index(string text1, string ddlListe, bool cbOnay, IFormCollection keyValuePairs)
        {
            // 1. Yöntem parametrelerden gelen veriler;
            /*
            ViewBag.Mesaj = "Textboxdan gelen veri : " + text1;
            ViewBag.MesajListe = "liste den seçilen değer : " + ddlListe;
            TempData["Tdata"] = "Checkbox dan seçilen değer : " + cbOnay;
            */
            // 2. Yöntem Request Form ile verileri yakalama

            ViewBag.Mesaj = "Textboxdan gelen veri : " + Request.Form["text1"];
            ViewBag.MesajListe = "liste den seçilen değer : " + Request.Form["ddlListe"];
            TempData["Tdata"] = "Checkbox dan seçilen değer : " + Request.Form["cbOnay"][0];// first() de kullanılabilir //true seçince true,false dönüyor
            //TempData["Tdata"] = "Checkbox dan seçilen değer : " + Request.Form.GetValues("cbOnay")[0];

            return View();
        }

    }
}
