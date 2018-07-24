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
    public class Client_HotelController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        ClientFactory _clientFactory;
        public Client_HotelController()
        {
            _clientFactory = new ClientFactory();
        }

        // GET: api/Client_Hotel        
        public IEnumerable<ClientHotelModel> GetClient_Hotel()
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllClient_Hotels().ToList().Select(c => _clientFactory.Create(c));
        }

        // GET: api/Client_Hotel/5        
        [Route("api/Client_Hotel/{id}")]
        public IEnumerable<ClientHotelModel> GetClient_Hotel(int id)
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllClient_Hotels(id).ToList().Select(c => _clientFactory.Create(c));
        }

        // PUT: api/Client_Hotel/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient_Hotel(Client_Hotel client_Hotel)
        {
            int id = client_Hotel.CH_Id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client_Hotel.CH_Id)
            {
                return BadRequest();
            }

            db.Entry(client_Hotel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Client_HotelExists(id))
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

        // POST: api/Client_Hotel
        [ResponseType(typeof(Client_Hotel))]
        public IHttpActionResult PostClient_Hotel(Client_Hotel client_Hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Client_Hotel.Add(client_Hotel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client_Hotel.CH_Id }, client_Hotel);
        }

        // DELETE: api/Client_Hotel/5
        [Route("api/Client_Hotel/{id}")]
        public IHttpActionResult DeleteClient_Hotel(int id)
        {
            Client_Hotel client_Hotel = db.Client_Hotel.Find(id);
            if (client_Hotel == null)
            {
                return NotFound();
            }

            db.Client_Hotel.Remove(client_Hotel);
            db.SaveChanges();

            return Ok(client_Hotel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Client_HotelExists(int id)
        {
            return db.Client_Hotel.Count(e => e.CH_Id == id) > 0;
        }
    }
}