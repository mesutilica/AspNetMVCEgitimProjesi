using AspNetMVCEgitimProjesi.NetCore.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMVCEgitimProjesi.NetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize] // CategoriesController daki tüm actionlara gelecek isteklerde oturum kontrolü yaptırdık bu şekilde.
    public class CategoriesController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        // GET: CategoriesController
        public ActionResult Index()
        {
            var kategoriler = context.Categories.ToList();

            return View(kategoriler);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                context.Categories.Add(category);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var kategori = context.Categories.FirstOrDefault(c => c.Id == id);

            if (kategori == null) return NotFound();

            return View(kategori);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                //context.Entry(category).State = EntityState.Modified;

                context.Update(category); // 2. güncelleme yöntemi

                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(context.Categories.Find(id)); // View içerisine dire entity frameworkden gelen kaydı da yollayabiliriz
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                //context.Categories.Remove(category); // 1. yöntem

                context.Entry(category).State = EntityState.Deleted; // 2. veri silme yöntemi

                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
