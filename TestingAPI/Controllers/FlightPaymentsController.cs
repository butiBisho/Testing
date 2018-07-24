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
    public class FlightPaymentsController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        ClientFactory _clientFactory;
        public FlightPaymentsController()
        {
            _clientFactory = new ClientFactory();
        }

        // GET: api/FlightPayments
        public IQueryable<FlightPayment> GetFlightPayments()
        {
            return db.FlightPayments;
        }

        // GET: api/FlightPayments/5        
        [Route("api/FlightPayments/{id}")]
        public IEnumerable<FlightPaymentModel> GetFlightPayment(int id)
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllFlightPaymentsByClientId(id).ToList().Select(c => _clientFactory.Create(c));
        }

        // PUT: api/FlightPayments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFlightPayment(FlightPayment flightPayment)
        {
            int id = flightPayment.FlightPaymentId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flightPayment.FlightPaymentId)
            {
                return BadRequest();
            }

            db.Entry(flightPayment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightPaymentExists(id))
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

        // POST: api/FlightPayments
        [ResponseType(typeof(FlightPayment))]
        public IHttpActionResult PostFlightPayment(FlightPayment flightPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FlightPayments.Add(flightPayment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = flightPayment.FlightPaymentId }, flightPayment);
        }

        // DELETE: api/FlightPayments/5
        [Route("api/FlightPayments/{id}")]
        public IHttpActionResult DeleteFlightPayment(int id)
        {
            FlightPayment flightPayment = db.FlightPayments.Find(id);
            if (flightPayment == null)
            {
                return NotFound();
            }

            db.FlightPayments.Remove(flightPayment);
            db.SaveChanges();

            return Ok(flightPayment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightPaymentExists(int id)
        {
            return db.FlightPayments.Count(e => e.FlightPaymentId == id) > 0;
        }
    }
}