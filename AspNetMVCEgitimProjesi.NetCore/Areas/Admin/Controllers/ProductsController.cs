using AspNetMVCEgitimProjesi.NetCore.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMVCEgitimProjesi.NetCore.Areas.Admin.Controllers
{
    [Area("Admin")]//, Authorize
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _context;

        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();

            products = _context.Products.ToList();

            return View(products);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, IFormFile? Image) // .net core da resim adını bu şekilde IFormFile olarak paramterye ekliyoruz
        {
            try
            {
                if (Image != null)
                {
                    string directory = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName; // resmin yükleneceği klasörü belirtiyoruz
                    using var stream = new FileStream(directory, FileMode.Create);
                    Image.CopyTo(stream);
                    product.Image = Image.FileName;
                }

                _context.Entry(product).State = EntityState.Added;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = _context.Products.Find(id);

            if (product == null) return NotFound();

            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product, IFormFile? Image)
        {
            try
            {
                if (Image != null)
                {
                    string directory = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName; // resmin yükleneceği klasörü belirtiyoruz
                    using var stream = new FileStream(directory, FileMode.Create);
                    Image.CopyTo(stream);
                    product.Image = Image.FileName;
                }

                _context.Products.Update(product);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);

            if (product == null) return NotFound();

            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
