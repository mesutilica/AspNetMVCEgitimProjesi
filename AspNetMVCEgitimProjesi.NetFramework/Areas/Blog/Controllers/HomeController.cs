using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Areas.Blog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Blog/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}