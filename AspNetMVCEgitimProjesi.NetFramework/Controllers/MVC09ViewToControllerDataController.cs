using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC09ViewToControllerDataController : Controller
    {
        // GET: MVC09ViewToControllerData
        public ActionResult Index(string txtAra)
        {
            ViewBag.GetVerisi = txtAra;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string text1, string ddlListe, bool cbOnay)
        {
            // 1. Yöntem parametrelerden gelen veriler;
            /*
            ViewBag.Mesaj = "Textboxdan gelen veri : " + text1;
            ViewBag.MesajListe = "liste den seçilen değer : " + ddlListe;
            TempData["Tdata"] = "Checkbox dan seçilen değer : " + cbOnay;
            */
            // 2. Yöntem Request Form ile verileri yakalama

            ViewBag.Mesaj = "Textboxdan gelen veri : " + Request.Form["text1"];
            ViewBag.MesajListe = "liste den seçilen değer : " + Request.Form["ddlListe"];
            //TempData["Tdata"] = "Checkbox dan seçilen değer : " + Request.Form["cbOnay"][0];// first() de kullanılabilir //true seçince true,false dönüyor
            TempData["Tdata"] = "Checkbox dan seçilen değer : " + Request.Form.GetValues("cbOnay")[0];
            return View();
        }
    }
}