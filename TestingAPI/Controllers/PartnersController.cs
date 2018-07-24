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
    public class PartnersController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        ClientFactory _clientFactory;
        public PartnersController()
        {
            _clientFactory = new ClientFactory();
        }

        // GET: api/Partners        
        public IEnumerable<PartnerModel> GetPartners()
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllPartners().ToList().Select(c => _clientFactory.Create(c));
        }

        // GET: api/Partners/5        
        [Route("api/Partners/{id}")]
        public IEnumerable<PartnerModel> GetPartner(int id)
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllPartners(id).ToList().Select(c => _clientFactory.Create(c));
        }

        // PUT: api/Partners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartner(Partner partner)
        {
            int id = partner.PartnerId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partner.PartnerId)
            {
                return BadRequest();
            }

            db.Entry(partner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerExists(id))
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

        // POST: api/Partners
        [ResponseType(typeof(Partner))]
        public IHttpActionResult PostPartner(Partner partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Partners.Add(partner);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = partner.PartnerId }, partner);
        }

        // DELETE: api/Partners/5
        [Route("api/Partners/{id}")]
        public IHttpActionResult DeletePartner(int id)
        {
            Partner partner = db.Partners.Find(id);
            if (partner == null)
            {
                return NotFound();
            }

            db.Partners.Remove(partner);
            db.SaveChanges();

            return Ok(partner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartnerExists(int id)
        {
            return db.Partners.Count(e => e.PartnerId == id) > 0;
        }
    }
}