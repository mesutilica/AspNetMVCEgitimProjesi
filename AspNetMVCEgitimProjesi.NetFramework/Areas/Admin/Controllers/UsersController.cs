using AspNetFramework.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetMVCEgitimProjesi.NetFramework.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        static string apiAdres = "https://localhost:44347/Api/Users/";
        HttpClient client = new HttpClient
        {
            BaseAddress = new Uri(apiAdres)
        };
        public UsersController()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); //media tipi
        }

        // GET: Admin/Users
        public async Task<ActionResult> Index()
        {
            var response = await client.GetAsync(""); //Users verisini getir
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync(); //JSON verisini oku
                var model = JsonConvert.DeserializeObject<List<User>>(data); //JSON verisini Post listesine dönüştür
                return View(model);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(User collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    var json = JsonConvert.SerializeObject(collection);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("Create", data);
                    // var result = await response.Content.ReadAsStringAsync();
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

        // GET: Admin/Users/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await client.GetAsync("" + id); //Users verisini getir
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync(); //JSON verisini oku
                var model = JsonConvert.DeserializeObject<User>(data); //JSON verisini Post listesine dönüştür
                return View(model);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        // POST: Admin/Users/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, User collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    var json = JsonConvert.SerializeObject(collection);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync("" + id, data);
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

        // GET: Admin/Users/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await client.GetAsync("" + id); //Users verisini getir
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync(); //JSON verisini oku
                var user = JsonConvert.DeserializeObject<User>(data); //JSON verisini Post listesine dönüştür
                return View(user);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, User collection)
        {
            try
            {
                // TODO: Add delete logic here
                var response = await client.DeleteAsync("" + id);
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
