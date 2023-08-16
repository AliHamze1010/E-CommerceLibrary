using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using E_CommerceLibrary.Models;

namespace E_CommerceLibrary.Controllers
{
    public class BookController : Controller
    {
        private string _apiUrl = "https://localhost:44312/api/BookData";

        // GET: Book
        public ActionResult Index()
        {
            IEnumerable<Book> books = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                var responseTask = client.GetAsync("GetBooks");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Book>>();
                    readTask.Wait();

                    books = readTask.Result;
                }
                else
                {
                    books = Enumerable.Empty<Book>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact the administrator.");
                }
            }
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            Book book = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                var responseTask = client.GetAsync($"GetBook/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Book>();
                    readTask.Wait();

                    book = readTask.Result;
                }
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);

                var postTask = client.PostAsJsonAsync<Book>("PostBook", book);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server error. Please contact the administrator.");

            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                var responseTask = client.GetAsync($"GetBook/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Book>();
                    readTask.Wait();

                    book = readTask.Result;
                }
            }
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                var putTask = client.PutAsJsonAsync($"PutBook/{book.BookID}", book);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                var responseTask = client.GetAsync($"GetBook/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Book>();
                    readTask.Wait();

                    book = readTask.Result;
                }
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                var deleteTask = client.DeleteAsync($"DeleteBook/{id}");
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
