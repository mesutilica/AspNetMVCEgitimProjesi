using AspNetMVCEgitimProjesi.NetFramework.Models;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC08PartialController : Controller
    {
        private UyeContext db = new UyeContext();
        // GET: MVC08Partial
        public ActionResult Index()
        {
            return View(db.Uyeler.ToList());
        }
    }
}