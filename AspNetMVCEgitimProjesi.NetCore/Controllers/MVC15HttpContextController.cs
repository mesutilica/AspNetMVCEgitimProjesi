using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC15HttpContextController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public MVC15HttpContextController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            var mesaj = " Controller : " + _contextAccessor.HttpContext.GetRouteValue("Controller");
            mesaj += "<hr/> Action : " + HttpContext.GetRouteValue("Action");
            mesaj += "<hr/> Id : " + HttpContext.GetRouteValue("id");
            mesaj += "<hr/> Kelime : " + HttpContext.Request.Query["kelime"];
            TempData["mesaj"] = mesaj;
            return View();
        }
    }
}
