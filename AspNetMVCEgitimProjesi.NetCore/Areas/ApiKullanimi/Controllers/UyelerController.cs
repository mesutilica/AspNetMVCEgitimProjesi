using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Areas.ApiKullanimi.Controllers
{
    [Area("ApiKullanimi")]
    // [Authorize(Policy = "AdminPolicy")]
    public class UyelerController : Controller
    {
        private readonly HttpClient _httpClient;
        string _apiAdres = "https://localhost:7063/api/Uyeler/";

        public UyelerController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: UyelerController
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Uye>>(_apiAdres);
            return View(model);
        }

        // GET: UyelerController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var model = await _httpClient.GetFromJsonAsync<Uye>(_apiAdres + id);
            return View(model);
        }

        // GET: UyelerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UyelerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Uye collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _httpClient.PostAsJsonAsync(_apiAdres, collection);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                    ModelState.AddModelError("", "Kayıt Başarısız!");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(collection);
        }

        // GET: UyelerController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _httpClient.GetFromJsonAsync<Uye>(_apiAdres + id);
            return View(model);
        }

        // POST: UyelerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Uye collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _httpClient.PutAsJsonAsync(_apiAdres + id, collection);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                    ModelState.AddModelError("", "Kayıt Başarısız!");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(collection);
        }

        // GET: UyelerController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _httpClient.GetFromJsonAsync<Uye>(_apiAdres + id);
            return View(model);
        }

        // POST: UyelerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Uye collection)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(_apiAdres + id);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Kayıt Silinemedi!");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(collection);
        }
    }
}
