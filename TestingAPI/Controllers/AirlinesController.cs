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
    public class AirlinesController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        AdminFactory _adminFactory;
        public AirlinesController()
        {
            _adminFactory = new AdminFactory();
        }

        // GET: api/Airlines        
        public IEnumerable<AirlineModel> GetAirlines()
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllAirlines().ToList().Select(c => _adminFactory.Create(c));
        }

        // GET: api/Airlines/5
        [Route("api/Airlines/{id}")]
        public IEnumerable<AirlineModel> GetAirline(int id)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllAirlines(id).ToList().Select(c => _adminFactory.Create(c));
        }

        [Route("api/Airlines/{airline}/{id}")]
        public IEnumerable<AirlineModel> GetIATA(string airline, int id)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetIATA(airline, id).ToList().Select(c => _adminFactory.Create(c));
        }

        // PUT: api/Airlines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAirline(Airline airline)
        {
            int id = airline.AirlineId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != airline.AirlineId)
            {
                return BadRequest();
            }

            db.Entry(airline).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirlineExists(id))
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

        // POST: api/Airlines
        [ResponseType(typeof(Airline))]
        public IHttpActionResult PostAirline(Airline airline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Airlines.Add(airline);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = airline.AirlineId }, airline);
        }

        // DELETE: api/Airlines/5
        [Route("api/Airlines/{id}")]
        public IHttpActionResult DeleteAirline(int id)
        {
            Airline airline = db.Airlines.Find(id);
            if (airline == null)
            {
                return NotFound();
            }

            db.Airlines.Remove(airline);
            db.SaveChanges();

            return Ok(airline);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AirlineExists(int id)
        {
            return db.Airlines.Count(e => e.AirlineId == id) > 0;
        }
    }
}