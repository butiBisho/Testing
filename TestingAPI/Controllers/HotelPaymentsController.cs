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
    public class HotelPaymentsController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        ClientFactory _clientFactory;
        public HotelPaymentsController()
        {
            _clientFactory = new ClientFactory();
        }

        // GET: api/HotelPayments
        public IQueryable<HotelPayment> GetHotelPayments()
        {
            return db.HotelPayments;
        }

        // GET: api/HotelPayments/5        
        [Route("api/HotelPayments/{id}")]
        public IEnumerable<HotelPaymentModel> GetHotelPayment(int id)
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllHotelPaymentsByClientId(id).ToList().Select(c => _clientFactory.Create(c));
        }

        // PUT: api/HotelPayments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHotelPayment(HotelPayment hotelPayment)
        {
            int id = hotelPayment.HotelPaymentId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotelPayment.HotelPaymentId)
            {
                return BadRequest();
            }

            db.Entry(hotelPayment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelPaymentExists(id))
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

        // POST: api/HotelPayments
        [ResponseType(typeof(HotelPayment))]
        public IHttpActionResult PostHotelPayment(HotelPayment hotelPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HotelPayments.Add(hotelPayment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hotelPayment.HotelPaymentId }, hotelPayment);
        }

        // DELETE: api/HotelPayments/5
        [Route("api/HotelPayments/{id}")]
        public IHttpActionResult DeleteHotelPayment(int id)
        {
            HotelPayment hotelPayment = db.HotelPayments.Find(id);
            if (hotelPayment == null)
            {
                return NotFound();
            }

            db.HotelPayments.Remove(hotelPayment);
            db.SaveChanges();

            return Ok(hotelPayment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HotelPaymentExists(int id)
        {
            return db.HotelPayments.Count(e => e.HotelPaymentId == id) > 0;
        }
    }
}