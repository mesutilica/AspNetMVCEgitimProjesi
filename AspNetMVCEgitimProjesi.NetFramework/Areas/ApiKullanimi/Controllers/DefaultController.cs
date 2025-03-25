using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Areas.ApiKullanimi.Controllers
{
    public class DefaultController : Controller
    {
        // GET: ApiKullanimi/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}