using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCEgitimKonulari.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UyelerController : Controller
    {
        private readonly UyeContext _context;

        public UyelerController(UyeContext context)
        {
            _context = context;
        }

        // GET: MVC06CRUD
        public async Task<IActionResult> Index()
        {
            return View(await _context.Uyeler.ToListAsync());
        }

        // GET: MVC06CRUD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uye = await _context.Uyeler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uye == null)
            {
                return NotFound();
            }

            return View(uye);
        }

        // GET: MVC06CRUD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MVC06CRUD/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Uye uye)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uye);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uye);
        }

        // GET: MVC06CRUD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uye = await _context.Uyeler.FindAsync(id);
            if (uye == null)
            {
                return NotFound();
            }
            return View(uye);
        }

        // POST: MVC06CRUD/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Uye uye)
        {
            if (id != uye.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uye);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UyeExists(uye.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(uye);
        }

        // GET: MVC06CRUD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uye = await _context.Uyeler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uye == null)
            {
                return NotFound();
            }

            return View(uye);
        }

        // POST: MVC06CRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uye = await _context.Uyeler.FindAsync(id);
            if (uye != null)
            {
                _context.Uyeler.Remove(uye);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UyeExists(int id)
        {
            return _context.Uyeler.Any(e => e.Id == id);
        }
    }
}
