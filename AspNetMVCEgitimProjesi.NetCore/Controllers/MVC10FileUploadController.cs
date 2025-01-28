using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC10FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormFile? dosya) // Mvc de dosya yükleme IFormFile interface i ile yapılıyor. Burada dosya isminin ekrandaki file upload name i ile aynı olması gerekir yoksa dosya yüklenmez!
        {
            if (dosya != null)
            {
                var uzanti = Path.GetExtension(dosya.FileName); // yüklenecek dosya uzantısı
                string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Images/";
                var klasorVarmi = Directory.Exists(klasor);
                TempData["Message"] = "klasorVarmi : " + klasorVarmi;
                if (klasorVarmi == false) // eğer sunucuda bu konumda klasör yoksa
                {
                    var sonuc = Directory.CreateDirectory(klasor); // ana dizine Images klasörü oluştur
                    TempData["Message"] += " - Klasör Oluşturuldu.. " + sonuc;
                }
                if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png" || uzanti == ".gif") // Sadece bu uzantılardaki dosyaları kabul et
                {
                    // 1. Yöntem Random(Rastgele) İsimle Dosya Yükleme
                    var randomFileName = Path.GetRandomFileName(); // rasgele dosya ismi oluşturma metodu
                    var fileName = Path.ChangeExtension(randomFileName, ".jpg"); // dosya adı ve uzantısını değiştirip birleştirdik
                    var path = Path.Combine(klasor, fileName); // klasör ve resim adını birleştirdik
                    //using var stream = new FileStream(path, FileMode.Create);

                    // 2. Yöntem - Resmi Kendi Adıyla Yükleme
                    var dosyaAdi = Path.GetFileName(dosya.FileName);
                    var yol = Path.Combine(klasor, dosyaAdi);
                    using var stream = new FileStream(yol, FileMode.Create);

                    //using var stream = new FileStream(klasor + dosya.FileName, FileMode.Create); // Buradaki using ifadesi stream isimli değişkenin işinin bittikten sonra bellekten atılmasını sağlar
                    dosya.CopyTo(stream); // resmi asenkron olarak yükledik
                    TempData["Resim"] = dosya.FileName;
                }
                else TempData["message"] = "Sadece .jpg, .jpeg, .png, .gif Resimleri Yükleyebilirsiniz! ";
            }
            return View();
        }
        [HttpPost]
        public ActionResult ResimSil(string resimYolu)
        {
            if (System.IO.File.Exists(resimYolu))
            {
                System.IO.File.Delete(resimYolu);
                TempData["message"] = "Resim Silindi!";
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}
