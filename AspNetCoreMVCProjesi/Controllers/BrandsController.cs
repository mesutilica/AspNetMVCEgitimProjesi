using AspNetCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCProjesi.Controllers
{
    public class BrandsController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public BrandsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var markalar = await _databaseContext.Brands.AsNoTracking().ToListAsync();

            return View(markalar);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return BadRequest(); // adres çubuğundan id gönderilmemişse ekrana sayfa bulunamadı hatası dön

            if (id != null) // Eğer adres çubuğunda Products controller a id gönderilmişse
            {
                var kayit = _databaseContext.Brands.Include(c => c.Products).FirstOrDefault(p => p.Id == id);// Kategorilerden ıd si adres çubuğundan gelen id ile eşleşen kaydı getir ve o kategorinin ürünlerini de kayda include ile dahil et
                if (kayit == null) return NotFound(); // eğer adres çubuğundan gönderilen id ye ait bir kategori veritabanında yoksa geriye notfound yani bulunamadı hatası dön.
                return View(kayit); // Eğer kategori bulunduysa bulunan kaydı sayfaya gönder
            }
            return View();
        }
    }
}
