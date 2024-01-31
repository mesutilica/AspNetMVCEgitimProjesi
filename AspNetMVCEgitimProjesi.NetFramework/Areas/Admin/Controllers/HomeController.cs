using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int? id)
        {
            if (id is null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View();
        }
    }
}