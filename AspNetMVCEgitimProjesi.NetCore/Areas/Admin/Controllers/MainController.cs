using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Areas.Admin.Controllers
{
    [Area("Admin")] // Aşağıdaki controller içerisindeki actionların admin areasında çalışması için bu attribute ü yazmamız gerekli!
    public class MainController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
