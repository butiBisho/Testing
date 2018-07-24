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
    public class CarPaymentsController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        ClientFactory _clientFactory;
        public CarPaymentsController()
        {
            _clientFactory = new ClientFactory();
        }

        // GET: api/CarPayments
        public IQueryable<CarPayment> GetCarPayments()
        {
            return db.CarPayments;
        }

        // GET: api/CarPayments/5        
        [Route("api/CarPayments/{id}")]
        public IEnumerable<CarPaymentModel> GetCarPayment(int id)
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllCarPaymentsByClientId(id).ToList().Select(c => _clientFactory.Create(c));
        }

        // PUT: api/CarPayments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarPayment(CarPayment carPayment)
        {
            int id = carPayment.PaymentId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carPayment.PaymentId)
            {
                return BadRequest();
            }

            db.Entry(carPayment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarPaymentExists(id))
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

        // POST: api/CarPayments
        [ResponseType(typeof(CarPayment))]
        public IHttpActionResult PostCarPayment(CarPayment carPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CarPayments.Add(carPayment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carPayment.PaymentId }, carPayment);
        }

        // DELETE: api/CarPayments/5
        [Route("api/CarPayments/{id}")]
        public IHttpActionResult DeleteCarPayment(int id)
        {
            CarPayment carPayment = db.CarPayments.Find(id);
            if (carPayment == null)
            {
                return NotFound();
            }

            db.CarPayments.Remove(carPayment);
            db.SaveChanges();

            return Ok(carPayment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarPaymentExists(int id)
        {
            return db.CarPayments.Count(e => e.PaymentId == id) > 0;
        }
    }
}