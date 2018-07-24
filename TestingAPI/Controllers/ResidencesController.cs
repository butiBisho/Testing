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
    public class ResidencesController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        AdminFactory _adminFactory;
        public ResidencesController()
        {
            _adminFactory = new AdminFactory();
        }

        // GET: api/Residences
        public IEnumerable<ResidenceModel> GetResidences()
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllResidences().ToList().Select(c => _adminFactory.Create(c));
        }

        // GET: api/Residences/5        
        [Route("api/Residences/{id}")]
        public IEnumerable<ResidenceModel> GetResidence(int id)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllResidences(id).ToList().Select(c => _adminFactory.Create(c));
        }

        // PUT: api/Residences/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResidence(Residence residence)
        {
            int id = residence.LocationID;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != residence.LocationID)
            {
                return BadRequest();
            }

            db.Entry(residence).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidenceExists(id))
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

        // POST: api/Residences
        [ResponseType(typeof(Residence))]
        public IHttpActionResult PostResidence(Residence residence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Residences.Add(residence);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = residence.LocationID }, residence);
        }

        // DELETE: api/Residences/5
        [Route("api/Residences/{id}")]
        public IHttpActionResult DeleteResidence(int id)
        {
            Residence residence = db.Residences.Find(id);
            if (residence == null)
            {
                return NotFound();
            }

            db.Residences.Remove(residence);
            db.SaveChanges();

            return Ok(residence);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResidenceExists(int id)
        {
            return db.Residences.Count(e => e.LocationID == id) > 0;
        }
    }
}