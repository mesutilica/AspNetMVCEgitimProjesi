using AspNetCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCProjesi.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public CategoriesController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index(int? id)
        {
            if (id == null) return BadRequest(); // adres çubuğundan id gönderilmemişse ekrana sayfa bulunamadı hatası dön

            if (id != null) // Eğer adres çubuğunda Products controller a id gönderilmişse
            {
                var kategori = _databaseContext.Categories.Include(c => c.Products).FirstOrDefault(p => p.Id == id);// Kategorilerden ıd si adres çubuğundan gelen id ile eşleşen kaydı getir ve o kategorinin ürünlerini de kayda include ile dahil et
                if (kategori == null) return NotFound(); // eğer adres çubuğundan gönderilen id ye ait bir kategori veritabanında yoksa geriye notfound yani bulunamadı hatası dön.
                return View(kategori); // Eğer kategori bulunduysa bulunan kaydı sayfaya gönder
            }
            return View();
        }
    }
}
