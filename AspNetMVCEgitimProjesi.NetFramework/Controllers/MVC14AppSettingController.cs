using System.Web.Configuration;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC14AppSettingController : Controller
    {
        // GET: MVC13AppSetting
        public ActionResult Index()
        {
            ViewBag.MailinGidecegiAdres = WebConfigurationManager.AppSettings["EmailAdresi"];
            ViewBag.MailKullaniciAdi = WebConfigurationManager.AppSettings["EmailUsername"];
            ViewBag.MailSifre = WebConfigurationManager.AppSettings["EmailPassword"];
            return View();
        }
    }
}