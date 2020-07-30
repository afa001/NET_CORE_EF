using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEBAPP.Helper;
using WEBAPP.Models;

namespace WEBAPP.Controllers
{
    public class ProductoController : Controller
    {
        Service s = new Service();

        // GET: ProductoController
        public async Task<ActionResult> Index(string tipo)
        {
            List<Producto> productos = new List<Producto>();
            HttpClient client = s.Initial();
            HttpResponseMessage response;
            response = await client.GetAsync("api/Producto");

            //validate parameter tipo
            if (!String.IsNullOrEmpty(tipo))
            {
                //response = await client.GetAsync("api/Producto/?tipo="+tipo.ToString());
                response = await client.GetAsync("api/Producto/?tipo="+tipo.ToString());
            }

            //validate api response
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                productos = JsonConvert.DeserializeObject<List<Producto>>(results);
            }

            return View(productos);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            try
            {
                // TODO: Add insert logic here
                HttpClient client = s.Initial();
                var postTask = client.PostAsJsonAsync<Producto>("api/Producto", producto);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var p = new Producto();
            HttpClient client = s.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Producto/" + id);

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                p = JsonConvert.DeserializeObject<Producto>(results);
            }

            return View(p);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Producto producto)
        {
            try
            {
                // TODO: Add update logic here
                HttpClient client = s.Initial();
                HttpResponseMessage response = client.PutAsJsonAsync("api/Producto/" + producto.Id, producto).Result;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var p = new Producto();

            try
            {
                HttpClient client = s.Initial();
                HttpResponseMessage res = await client.GetAsync("api/Producto/" + id);

                if (res.IsSuccessStatusCode)
                {
                    var results = res.Content.ReadAsStringAsync().Result;
                    p = JsonConvert.DeserializeObject<Producto>(results);
                }
                return View(p);

            }
            catch (Exception)
            {

                    return View(p);
            }

        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id,Producto producto)
        {
            try
            {
                // TODO: Add delete logic here
                //var p = new Producto();
                HttpClient client = s.Initial();
                HttpResponseMessage response = await client.DeleteAsync("api/Producto/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
