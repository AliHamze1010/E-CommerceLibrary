using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using E_CommerceLibrary.Models;

namespace E_CommerceLibrary.Controllers
{
    public class BuyerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Buyer
        public ActionResult Index()
        {
            var buyers = db.Buyers.ToList();
            return View(buyers);
        }

        // GET: Buyer/Details/5
        public ActionResult Details(int id)
        {
            var buyer = db.Buyers.Find(id);
            if (buyer == null)
            {
                return HttpNotFound();
            }
            return View(buyer);
        }

        // GET: Buyer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buyer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BuyerID,BuyerName,BookID")] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                db.Buyers.Add(buyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buyer);
        }

        // GET: Buyer/Edit/5
        public ActionResult Edit(int id)
        {
            var buyer = db.Buyers.Find(id);
            if (buyer == null)
            {
                return HttpNotFound();
            }
            return View(buyer);
        }

        // POST: Buyer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuyerID,BuyerName,BookID")] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buyer);
        }

        // GET: Buyer/Delete/5
        public ActionResult Delete(int id)
        {
            var buyer = db.Buyers.Find(id);
            if (buyer == null)
            {
                return HttpNotFound();
            }
            return View(buyer);
        }

        // POST: Buyer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var buyer = db.Buyers.Find(id);
            db.Buyers.Remove(buyer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
