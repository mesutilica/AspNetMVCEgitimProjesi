using AspNetCore.Data;
using AspNetCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public ProductsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index(int? id)
        {
            var model = new List<Product>();
            if (id == null) model = _databaseContext.Products.ToList();
            else model = _databaseContext.Products.Where(p => p.CategoryId == id).ToList();
            return View(model);
        }

        public IActionResult Search(string? q)
        {
            if (q != null)
            {
                ViewBag.Title = q;
                return View(_databaseContext.Products.Where(p => p.Name.Contains(q)).ToList());
            }
            return View(_databaseContext.Products.ToList());
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest(); // eğer adres çubuğundan id değeri gönderilmemişse geriye geçersiz istek hatası dön
            return View(await _databaseContext.Products.Include("Brand").Include(c => c.Category).FirstOrDefaultAsync(p => p.Id == id));
        }
    }
}
