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
    public class Client_CarController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        ClientFactory _clientFactory;
        public Client_CarController()
        {
            _clientFactory = new ClientFactory();
        }

        // GET: api/Client_Car        
        public IEnumerable<ClientCarModel> GetClient_Car()
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllClient_Cars().ToList().Select(c => _clientFactory.Create(c));
        }

        // GET: api/Client_Car/5        
        [Route("api/Client_Car/{id}")]
        public IEnumerable<ClientCarModel> GetClient_Car(int id)
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllClient_Cars(id).ToList().Select(c => _clientFactory.Create(c));
        }

        // PUT: api/Client_Car/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient_Car(Client_Car client_Car)
        {
            int id = client_Car.CC_Id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client_Car.CC_Id)
            {
                return BadRequest();
            }

            db.Entry(client_Car).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Client_CarExists(id))
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

        // POST: api/Client_Car
        [ResponseType(typeof(Client_Car))]
        public IHttpActionResult PostClient_Car(Client_Car client_Car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Client_Car.Add(client_Car);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client_Car.CC_Id }, client_Car);
        }

        // DELETE: api/Client_Car/5
        [Route("api/Client_Car/{id}")]
        public IHttpActionResult DeleteClient_Car(int id)
        {
            Client_Car client_Car = db.Client_Car.Find(id);
            if (client_Car == null)
            {
                return NotFound();
            }

            db.Client_Car.Remove(client_Car);
            db.SaveChanges();

            return Ok(client_Car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Client_CarExists(int id)
        {
            return db.Client_Car.Count(e => e.CC_Id == id) > 0;
        }
    }
}