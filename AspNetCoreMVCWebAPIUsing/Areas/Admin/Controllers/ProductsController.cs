using AspNetCore.Entities;
using AspNetCoreMVCWebAPIUsing.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreMVCWebAPIUsing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiAdres = "https://localhost:7116/api/";

        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // GET: ProductsController
        public async Task<IActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Product>>(_apiAdres + "Products");
            return View(model);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.CategoryId = new SelectList(await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdres + "Categories"), "Id", "Name");
            ViewBag.BrandId = new SelectList(await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdres + "Brands"), "Id", "Name");
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Product entity, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    entity.Image = await FileHelper.FileLoaderAsync(Image);
                    var response = await _httpClient.PostAsJsonAsync(_apiAdres + "Products", entity);
                    if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
                    ModelState.AddModelError("", "Kayıt Eklenemedi!");
                }
                catch (Exception hata)
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                    ViewData["Err"] = hata.Message;
                }
            }
            ViewBag.CategoryId = new SelectList(await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdres + "Categories"), "Id", "Name");
            ViewBag.BrandId = new SelectList(await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdres + "Brands"), "Id", "Name");
            return View(entity);
        }

        // GET: ProductsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdres + "Categories"), "Id", "Name");
            ViewBag.BrandId = new SelectList(await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdres + "Brands"), "Id", "Name");
            return View(await _httpClient.GetFromJsonAsync<Product>($"{_apiAdres + "Products"}/{id}"));
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product entity, IFormFile? Image, bool resmiSil = false)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (resmiSil == true) 
                        entity.Image = string.Empty;
                    if (Image != null) 
                        entity.Image = await FileHelper.FileLoaderAsync(Image);
                    var response = await _httpClient.PutAsJsonAsync($"{_apiAdres + "Products"}/{id}", entity);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                    ModelState.AddModelError("", "Kayıt Güncellenemedi!");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.CategoryId = new SelectList(await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdres + "Categories"), "Id", "Name");
            ViewBag.BrandId = new SelectList(await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdres + "Brands"), "Id", "Name");
            return View(entity);
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            return View(await _httpClient.GetFromJsonAsync<Product>($"{_apiAdres + "Products"}/{id}"));
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Product entity)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_apiAdres + "Products"}/{id}");
                if (response.IsSuccessStatusCode) 
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", "Kayıt Güncellenemedi!");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(entity);
        }
    }
}
