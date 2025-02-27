using System.Web.Configuration;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC14AppSettingController : Controller
    {
        // GET: MVC14AppSetting
        public ActionResult Index()
        {
            ViewBag.Mesaj = $"Email: {WebConfigurationManager.AppSettings["Email"]}";
            ViewBag.Mesaj += $" - MailSunucu: {WebConfigurationManager.AppSettings["MailSunucu"]}";
            ViewBag.Mesaj += $" - UserName: {WebConfigurationManager.AppSettings["Username"]}";
            ViewBag.Mesaj += $" - Password: {WebConfigurationManager.AppSettings["Password"]}";
            return View();
        }
    }
}