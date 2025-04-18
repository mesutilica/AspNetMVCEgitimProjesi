using AspNetMVCEgitimProjesi.NetFramework.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Controllers
{
    public class MVC06CRUDController : Controller
    {
        private UyeContext db = new UyeContext();

        // GET: MVC06CRUD
        public ActionResult Index()
        {
            return View(db.Uyeler.ToList());
        }

        // GET: MVC06CRUD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uyeler.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        // GET: MVC06CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MVC06CRUD/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Uye uye)
        {
            if (ModelState.IsValid)
            {
                db.Uyeler.Add(uye);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uye);
        }

        // GET: MVC06CRUD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var uye = context.Uyes.Where(b => b.Id == id).FirstOrDefault();
            //var uye = context.Uyes.Where(b => b.Id == id).SingleOrDefault();
            //var uye = context.Uyes.FirstOrDefault(b => b.Id == id);
            //var uye = context.Uyes.SingleOrDefault(b => b.Id == id);
            Uye uye = db.Uyeler.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        // POST: MVC06CRUD/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Uye uye)
        {
            if (ModelState.IsValid)
            {
                // context.Update(uye);
                // context.Uyes.Update(uye);
                // context.Attach<Uye>(uye).State = EntityState.Modified;
                // context.Entry(uye).State = EntityState.Modified;
                // context.Entry<Uye>(uye).State = EntityState.Modified;
                // context.Entry(uye).State = EntityState.Modified;
                // context.SaveChanges();
                db.Entry(uye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uye);
        }

        // GET: MVC06CRUD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uyeler.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        // POST: MVC06CRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uye uye = db.Uyeler.Find(id);
            // context.Remove(uye);
            // context.Attach<Uye>(uye).State = EntityState.Deleted;
            // context.Entry(uye).State = EntityState.Deleted;
            // context.Entry<Uye>(uye).State = EntityState.Deleted;
            db.Uyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
