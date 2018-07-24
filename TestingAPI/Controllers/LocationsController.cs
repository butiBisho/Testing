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
    public class LocationsController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        AdminFactory _adminFactory;
        public LocationsController()
        {
            _adminFactory = new AdminFactory();
        }

        // GET: api/Locations
        public IEnumerable<LocationModel> GetLocations()
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllLocations().ToList().Select(c => _adminFactory.Create(c));
        }

        // GET: api/Locations/5
        [Route("api/Locations/{id}")]
        public IEnumerable<LocationModel> GetLocation(int id)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllLocations(id).ToList().Select(c => _adminFactory.Create(c));
        }

        // PUT: api/Locations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLocation(Location location)
        {
            int id = location.LocationId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != location.LocationId)
            {
                return BadRequest();
            }

            db.Entry(location).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/Locations
        [ResponseType(typeof(Location))]
        public IHttpActionResult PostLocation(Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Locations.Add(location);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = location.LocationId }, location);
        }

        // DELETE: api/Locations/5
        [Route("api/Locations/{id}")]
        public IHttpActionResult DeleteLocation(int id)
        {
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return NotFound();
            }

            db.Locations.Remove(location);
            db.SaveChanges();

            return Ok(location);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocationExists(int id)
        {
            return db.Locations.Count(e => e.LocationId == id) > 0;
        }
    }
}