using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC17HttpContextAccessorController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public MVC17HttpContextAccessorController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            var mesaj = " Controller : " + _contextAccessor.HttpContext.GetRouteValue("Controller");
            mesaj += "<hr/> Action : " + _contextAccessor.HttpContext.GetRouteValue("Action");
            mesaj += "<hr/> Id : " + _contextAccessor.HttpContext.GetRouteValue("id");
            mesaj += "<hr/> Kelime : " + _contextAccessor.HttpContext.Request.Query["kelime"];
            TempData["mesaj"] = mesaj;
            return View();
        }
    }
}
