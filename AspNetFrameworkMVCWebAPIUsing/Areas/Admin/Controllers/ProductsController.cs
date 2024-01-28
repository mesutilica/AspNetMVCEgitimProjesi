using AspNetFramework.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetFrameworkMVCWebAPIUsing.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        static string apiAdres = "https://localhost:44347/Api/Products/";
        HttpClient client = new HttpClient();
        // GET: Admin/Products
        public async Task<ActionResult> Index()
        {
            var response = await client.GetAsync(apiAdres);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync(); //JSON verisini oku
                var model = JsonConvert.DeserializeObject<List<Product>>(data); //JSON verisini Post listesine dönüştür
                return View(model);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        public async Task<ActionResult> Create(Product collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(apiAdres + "Create", data);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(collection);
        }

        // GET: Admin/Products/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await client.GetAsync(apiAdres + id);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync(); //JSON verisini oku
                var model = JsonConvert.DeserializeObject<Product>(data); //JSON verisini Post listesine dönüştür
                return View(model);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Product collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(apiAdres + id, data);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(collection);
        }

        // GET: Admin/Products/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await client.GetAsync(apiAdres + id);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync(); //JSON verisini oku
                var model = JsonConvert.DeserializeObject<Product>(data); //JSON verisini Post listesine dönüştür
                return View(model);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Product collection)
        {
            try
            {
                var response = await client.DeleteAsync(apiAdres + id);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(collection);
        }
    }
}
