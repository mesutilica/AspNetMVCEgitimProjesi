using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index() // Bu action Index isimli view ı çalıştırır
        {
            // Index isimli view ı oluşturmak için üstteki Index e sağ tıklayıp açılan menüden Add View seçeneğine tıklıyoruz. Burada Mvc5 view ı seçip next butonuna basıp bir sonraki sayfada Add diyerek View ı oluşturuyoruz.
            return View();
        }
    }
}