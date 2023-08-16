using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using E_CommerceLibrary.Models;

namespace E_CommerceLibrary.Controllers
{
    public class SellerController : Controller
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:your_port_number/") };

        // GET: Seller
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync("api/SellerData");
            IEnumerable<Seller> sellers = response.Content.ReadAsAsync<IEnumerable<Seller>>().Result;
            return View(sellers);
        }

        // GET: Seller/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"api/SellerData/{id}");
            Seller seller = response.Content.ReadAsAsync<Seller>().Result;
            return View(seller);
        }

        // GET: Seller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seller/Create
        [HttpPost]
        public async Task<ActionResult> Create(Seller seller)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/SellerData", seller);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(seller);
        }

        // GET: Seller/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"api/SellerData/{id}");
            Seller seller = response.Content.ReadAsAsync<Seller>().Result;
            return View(seller);
        }

        // POST: Seller/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Seller seller)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/SellerData/{id}", seller);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(seller);
        }

        // GET: Seller/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"api/SellerData/{id}");
            Seller seller = response.Content.ReadAsAsync<Seller>().Result;
            return View(seller);
        }

        // POST: Seller/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/SellerData/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }
    }
}
