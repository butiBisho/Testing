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
using TestingAPI;
using TestingAPI.Models;

namespace TestingAPI.Controllers
{
    public class TravellersController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        ClientFactory _clientFactory;
        public TravellersController()
        {
            _clientFactory = new ClientFactory();
        }

        // GET: api/Travellers        
        public IEnumerable<TravellerModel> GetTravellers()
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllTravellers().ToList().Select(c => _clientFactory.Create(c));
        }

        // GET: api/Travellers/5        
        [Route("api/Travellers/{id}")]
        public IEnumerable<TravellerModel> GetTraveller(int id)
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllTravellers(id).ToList().Select(c => _clientFactory.Create(c));
        }

        // PUT: api/Travellers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTraveller(Traveller traveller)
        {
            int id = traveller.TravellerId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != traveller.TravellerId)
            {
                return BadRequest();
            }

            db.Entry(traveller).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravellerExists(id))
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

        // POST: api/Travellers
        [ResponseType(typeof(Traveller))]
        public IHttpActionResult PostTraveller(Traveller traveller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Travellers.Add(traveller);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = traveller.TravellerId }, traveller);
        }

        // DELETE: api/Travellers/5
        [Route("api/Travellers/{id}")]
        public IHttpActionResult DeleteTraveller(int id)
        {
            Traveller traveller = db.Travellers.Find(id);
            if (traveller == null)
            {
                return NotFound();
            }

            db.Travellers.Remove(traveller);
            db.SaveChanges();

            return Ok(traveller);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TravellerExists(int id)
        {
            return db.Travellers.Count(e => e.TravellerId == id) > 0;
        }
    }
}