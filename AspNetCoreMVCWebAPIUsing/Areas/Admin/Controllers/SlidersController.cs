using AspNetCore.Entities;
using AspNetCoreMVCWebAPIUsing.Utils;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCWebAPIUsing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7116/Api/Sliders";
        private readonly string _apiAdres2 = "https://localhost:7116/Api/Upload/";

        public SlidersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // GET: SlidersController
        public async Task<ActionResult> Index()
        {
            return View(await _httpClient.GetFromJsonAsync<List<Slider>>(_apiAdres));
        }

        // GET: SlidersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SlidersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SlidersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Slider entity, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var formDataResponse = await _httpClient.PostAsync(_apiAdres2, await FileHelper.ApiFileSenderAsync(Image));

                    entity.Image = await FileHelper.FileLoaderAsync(Image);
                    var response = await _httpClient.PostAsJsonAsync(_apiAdres, entity);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(entity);
        }

        // GET: SlidersController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            return View(await _httpClient.GetFromJsonAsync<Slider>($"{_apiAdres}/{id}"));
        }

        // POST: SlidersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Slider entity, IFormFile? Image, bool resmiSil = false)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (resmiSil == true)
                        entity.Image = string.Empty;
                    if (Image != null)
                        entity.Image = await FileHelper.FileLoaderAsync(Image);
                    var response = await _httpClient.PutAsJsonAsync($"{_apiAdres}", entity);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                    ModelState.AddModelError("", "Kayıt Güncellenemedi!");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(entity);
        }

        // GET: SlidersController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            return View(await _httpClient.GetFromJsonAsync<Slider>($"{_apiAdres}/{id}"));
        }

        // POST: SlidersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Slider entity)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_apiAdres}/{id}");
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", "İşlem Başarısız!");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(entity);
        }
    }
}
