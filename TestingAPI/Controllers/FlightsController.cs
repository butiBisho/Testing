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
    public class FlightsController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        AdminFactory _adminFactory;
        public FlightsController()
        {
            _adminFactory = new AdminFactory();
        }

        // GET: api/Flights        
        public IEnumerable<FlightModel> GetFlights()
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllFlights().ToList().Select(c => _adminFactory.Create(c));
        }

        // GET: api/Flights/5        
        [Route("api/Flights/{id}")]
        public IEnumerable<FlightModel> GetFlight(int id)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllFlights(id).ToList().Select(c => _adminFactory.Create(c));
        }

        [Route("api/Flights/{departureCity}/{arrivalCity}/{date}")]
        public IEnumerable<FlightModel> GetFlights(string departureCity, string arrivalCity, DateTime date)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllFlightsByLocation(departureCity, arrivalCity, date).ToList().Select(c => _adminFactory.Create(c));
        }

        // PUT: api/Flights/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFlight(Flight flight)
        {
            int id = flight.FlightId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flight.FlightId)
            {
                return BadRequest();
            }

            db.Entry(flight).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
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

        // POST: api/Flights
        [ResponseType(typeof(Flight))]
        public IHttpActionResult PostFlight(Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Flights.Add(flight);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = flight.FlightId }, flight);
        }

        // DELETE: api/Flights/5
        [Route("api/Flights/{id}")]
        public IHttpActionResult DeleteFlight(int id)
        {
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return NotFound();
            }

            db.Flights.Remove(flight);
            db.SaveChanges();

            return Ok(flight);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightExists(int id)
        {
            return db.Flights.Count(e => e.FlightId == id) > 0;
        }
    }
}