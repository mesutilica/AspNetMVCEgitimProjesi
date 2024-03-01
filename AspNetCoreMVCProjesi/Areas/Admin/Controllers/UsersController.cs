using AspNetCore.Data;
using AspNetCore.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCProjesi.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class UsersController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public UsersController(DatabaseContext databaseContext) // Dependency Injection
        {
            _databaseContext = databaseContext;
        }

        // GET: UsersController
        public async Task<ActionResult> Index() // async ifadesi bu metodun asenkron çalışacağını ifade eder
        {
            return View(await _databaseContext.Users.ToListAsync());
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create() // Get metotları sayfa ilk açıldığında çalışan metotlardır
        {
            return View(); // Eğer sayfa il açıldığında view a bir veri göndermemiz gerekirse bu blokta göndermeliyiz.
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(User appUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _databaseContext.Users.AddAsync(appUser);
                    await _databaseContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(appUser);
        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            // Ampülden make method async yi seçiyoruz
            return View(await _databaseContext.Users.FindAsync(id)); // FindAsync metodu kendisine verdiğimiz id ye sahip kaydı veritabanından bulup bize getirir
        }

        // POST: UsersController/Edit/5
        [HttpPost] // Aşağıdaki edit sadece sayfa post edilince çalışır
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(User appUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _databaseContext.Entry(appUser).State = EntityState.Modified;
                    await _databaseContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(appUser);
        }

        // GET: UsersController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            return View(await _databaseContext.Users.FindAsync(id));
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, User appUser)
        {
            try
            {
                _databaseContext.Entry(appUser).State = EntityState.Deleted;
                await _databaseContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
