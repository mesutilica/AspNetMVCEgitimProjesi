using AspNetCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AspNetCoreMVCEgitimKonulari.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        static string apiAdres = "https://localhost:7116/Api/Brands/";
        HttpClient client = new HttpClient(); // .net framework deki yapıyı kullanarak
        // GET: Admin/Brands
        public async Task<ActionResult> Index()
        {
            var response = await client.GetAsync(apiAdres);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync(); //JSON verisini oku
                var model = JsonConvert.DeserializeObject<List<Brand>>(data); //JSON verisini Post listesine dönüştür
                return View(model);
            }
            return NotFound();
        }

        // GET: Admin/Brands/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Brands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Brands/Create
        [HttpPost]
        public async Task<ActionResult> Create(Brand collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
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

        // GET: Admin/Brands/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await client.GetAsync(apiAdres + id);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync(); //JSON verisini oku
                var model = JsonConvert.DeserializeObject<Brand>(data); //JSON verisini Post listesine dönüştür
                return View(model);
            }
            return NotFound();
        }

        // POST: Admin/Brands/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Brand collection)
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

        // GET: Admin/Brands/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await client.GetAsync(apiAdres + id);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync(); //JSON verisini oku
                var model = JsonConvert.DeserializeObject<Brand>(data); //JSON verisini Post listesine dönüştür
                return View(model);
            }
            return NotFound();
        }

        // POST: Admin/Brands/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Brand collection)
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
