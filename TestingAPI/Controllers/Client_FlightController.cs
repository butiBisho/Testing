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
    public class Client_FlightController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        ClientFactory _clientFactory;
        public Client_FlightController()
        {
            _clientFactory = new ClientFactory();
        }

        // GET: api/Client_Flight        
        public IEnumerable<ClientFlightModel> GetClient_Flight()
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllClient_Flights().ToList().Select(c => _clientFactory.Create(c));
        }

        // GET: api/Client_Flight/5        
        [Route("api/Client_Flight/{id}")]
        public IEnumerable<ClientFlightModel> GetClient_Flight(int id)
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllClient_Flights(id).ToList().Select(c => _clientFactory.Create(c));
        }

        // PUT: api/Client_Flight/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient_Flight(Client_Flight client_Flight)
        {
            int id = client_Flight.CF_Id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client_Flight.CF_Id)
            {
                return BadRequest();
            }

            db.Entry(client_Flight).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Client_FlightExists(id))
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

        // POST: api/Client_Flight
        [ResponseType(typeof(Client_Flight))]
        public IHttpActionResult PostClient_Flight(Client_Flight client_Flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Client_Flight.Add(client_Flight);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client_Flight.CF_Id }, client_Flight);
        }

        // DELETE: api/Client_Flight/5
        [Route("api/Client_Flight/{id}")]
        public IHttpActionResult DeleteClient_Flight(int id)
        {
            Client_Flight client_Flight = db.Client_Flight.Find(id);
            if (client_Flight == null)
            {
                return NotFound();
            }

            db.Client_Flight.Remove(client_Flight);
            db.SaveChanges();

            return Ok(client_Flight);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Client_FlightExists(int id)
        {
            return db.Client_Flight.Count(e => e.CF_Id == id) > 0;
        }
    }
}