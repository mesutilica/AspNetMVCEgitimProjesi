using AspNetFramework.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Areas.Admin.Controllers
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
        public async Task<ActionResult> Create()
        {
            var response = await client.GetAsync("https://localhost:44347/Api/Categories/");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<Category>>(data);
                ViewBag.CategoryId = new SelectList(model, "Id", "Name");
            }
            var response2 = await client.GetAsync("https://localhost:44347/Api/Brands/");
            if (response2.IsSuccessStatusCode)
            {
                var data = await response2.Content.ReadAsStringAsync(); //JSON verisini oku
                var model = JsonConvert.DeserializeObject<List<Brand>>(data); //JSON verisini Post listesine dönüştür
                ViewBag.BrandId = new SelectList(model, "Id", "Name");
            }
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

                var response1 = await client.GetAsync("https://localhost:44347/Api/Categories/");
                if (response1.IsSuccessStatusCode)
                {
                    var dataCategory = await response1.Content.ReadAsStringAsync();
                    var model1 = JsonConvert.DeserializeObject<List<Category>>(dataCategory);
                    ViewBag.CategoryId = new SelectList(model1, "Id", "Name", model.CategoryId);
                }
                var response2 = await client.GetAsync("https://localhost:44347/Api/Brands/");
                if (response2.IsSuccessStatusCode)
                {
                    var data2 = await response2.Content.ReadAsStringAsync(); //JSON verisini oku
                    var model2 = JsonConvert.DeserializeObject<List<Brand>>(data2); //JSON verisini Post listesine dönüştür
                    ViewBag.BrandId = new SelectList(model2, "Id", "Name", model.BrandId);
                }

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
