using AspNetFramework.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetFrameworkMVCWebAPIUsing.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        static string apiAdres = "https://localhost:44347/Api/";
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
            var response = await client.GetAsync("Users"); //Users verisini getir
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync(); //JSON verisini oku
                var users = JsonConvert.DeserializeObject<List<User>>(data); //JSON verisini Post listesine dönüştür
                return View(users);
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Users/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await client.GetAsync("Users/" + id); //Users verisini getir
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync(); //JSON verisini oku
                var users = JsonConvert.DeserializeObject<User>(data); //JSON verisini Post listesine dönüştür
                return View(users);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        // POST: Admin/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Users/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await client.GetAsync("Users/" + id); //Users verisini getir
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync(); //JSON verisini oku
                var users = JsonConvert.DeserializeObject<User>(data); //JSON verisini Post listesine dönüştür
                return View(users);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
