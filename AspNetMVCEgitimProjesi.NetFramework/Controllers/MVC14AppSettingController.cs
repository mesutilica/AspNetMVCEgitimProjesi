using System.Web.Configuration;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC14AppSettingController : Controller
    {
        // GET: MVC14AppSetting
        public ActionResult Index()
        {
            ViewBag.Usr = WebConfigurationManager.AppSettings["EmailUserName"];
            ViewBag.Pwd = WebConfigurationManager.AppSettings["EmailPassWord"];
            return View();
        }
    }
}