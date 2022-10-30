using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC08ControllerToViewController : Controller
    {
        // GET: MVC08ControllerToView
        public ActionResult Index()
        {
            // MVC de temel olarak 3 türde view a veri yollama yapısı var
            // Örneğin veritabanından ürün bilgisini çekip ekrana  yollamak için
            // 1- ViewBag : Tek Kullanımlık Ömrü Var
            ViewBag.UrunKategorisi = "Bilgisayar";
            // 2-Viewdata : Tek Kullanımlık Ömrü Var
            ViewData["UrunAdi"] = "Acer Monitör";
            // 3-TempData : 2 Kullanımlık Ömrü Var
            TempData["UrunFiyati"] = 35.18;
            return View();
        }
    }
}