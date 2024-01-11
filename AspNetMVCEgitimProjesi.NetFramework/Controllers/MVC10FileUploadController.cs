using System.IO;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC10FileUploadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase dosya) // Ön yüzde file upload elementine name olarak ne isim verdiysek onu kullanmalıyız
        {
            if (dosya != null && dosya.ContentLength > 0)
            {
                // Dosya işlemleri için system.ıo kütüphanesini using ile yukarıya eklemeliyiz!
                var uzanti = Path.GetExtension(dosya.FileName); // Dosya uzantı kontrolü yapmak istersek
                if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png" || uzanti == ".gif") // Sadece bu uzantılardaki dosyaları kabul et
                {
                    // 1. Yöntem Random(Rastgele) İsimle Dosya Yükleme
                    var klasor = Server.MapPath("/Images"); // Resmi yükleyeceğimiz klasör(Eğer projede bu klasör yoksa oluşturmalıyız yoksa hata verir!)
                    var randomFileName = Path.GetRandomFileName(); // rasgele dosya ismi oluşturma metodu
                    var fileName = Path.ChangeExtension(randomFileName, ".jpg"); // dosya adı ve uzantısını değiştirip birleştirdik
                    var path = Path.Combine(klasor, fileName); // klasör ve resim adını birleştirdik
                    dosya.SaveAs(path); // resmi farklı kaydet metoduyla sunucuya yüklüyoruz.
                    //ViewBag.ResimAdi = fileName;
                    //ViewBag.ResimPath = path;

                    // 2. Yöntem - Resmi Kendi Adıyla Yükleme
                    var dosyaAdi = Path.GetFileName(dosya.FileName);
                    var yol = Path.Combine(klasor, dosyaAdi);

                    //dosya.SaveAs(yol);

                    // 3. Yönetm - Resmi direk sunucuya yollama
                    dosya.SaveAs(Server.MapPath("/Images/" + dosya.FileName));

                    ViewBag.ResimAdi = dosyaAdi;
                }
                else ViewData["message"] = "Sadece .jpg, .jpeg, .png, .gif Resimleri Yükleyebilirsiniz! ";
            }
            return View();
        }
    }
}
