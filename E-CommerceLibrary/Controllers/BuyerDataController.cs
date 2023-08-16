using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using E_CommerceLibrary.Models;

namespace E_CommerceLibrary.Controllers
{
    public class BuyerDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BuyerData
        public IQueryable<Buyer> GetBuyers()
        {
            return db.Buyers;
        }

        // GET: api/BuyerData/5
        [ResponseType(typeof(Buyer))]
        public IHttpActionResult GetBuyer(int id)
        {
            Buyer buyer = db.Buyers.Find(id);
            if (buyer == null)
            {
                return NotFound();
            }

            return Ok(buyer);
        }

        // PUT: api/BuyerData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBuyer(int id, Buyer buyer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != buyer.BuyerID)
            {
                return BadRequest();
            }

            db.Entry(buyer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BuyerData
        [ResponseType(typeof(Buyer))]
        public IHttpActionResult PostBuyer(Buyer buyer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Buyers.Add(buyer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = buyer.BuyerID }, buyer);
        }

        // DELETE: api/BuyerData/5
        [ResponseType(typeof(Buyer))]
        public IHttpActionResult DeleteBuyer(int id)
        {
            Buyer buyer = db.Buyers.Find(id);
            if (buyer == null)
            {
                return NotFound();
            }

            db.Buyers.Remove(buyer);
            db.SaveChanges();

            return Ok(buyer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BuyerExists(int id)
        {
            return db.Buyers.Count(e => e.BuyerID == id) > 0;
        }
    }
}