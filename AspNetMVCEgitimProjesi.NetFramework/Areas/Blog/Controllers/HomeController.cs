using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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