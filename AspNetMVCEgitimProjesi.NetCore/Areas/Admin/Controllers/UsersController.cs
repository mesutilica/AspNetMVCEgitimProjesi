using AspNetMVCEgitimProjesi.NetCore.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize] // soldakini yazmazsak sayfalar açılmıyor!!
    public class UsersController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        // GET: UsersController
        public ActionResult Index()
        {
            var kullaniciListesi = context.Users.ToList(); // kullaniciListesi isimli değişkene context üzerindeki users tablosundaki tüm verileri listele

            return View(kullaniciListesi); // view içerisinde çektiğimiz listeyi sayfaya yolladık
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(user);
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) // Eğer url den id yollanmamışsa
            {
                return BadRequest(); // Kullanıcıya Http dönüş türlerinden bozuk istek hatası dön
            }
            var model = context.Users.Find(id); // veritabanındaki users tablosundan ef find metoduyla adres çubuğundan gönderilen id ile eşleşen kaydı çek ve bana getir

            return View(model); // db den id ye göre çektiğimiz modeli sayfaya gönderdik
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified; // context üzerinden parametrede gönderilen user nesnesine abone ol(değişikliklerini takip et) ve bu nesneyi modified yani değiştirildi olarak işaretle

                context.SaveChanges(); // context üzerindeki değişiklikleri veritabanına işle

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(user);
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            User user = context.Users.SingleOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            return View(user);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                context.Users.Remove(user);
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
