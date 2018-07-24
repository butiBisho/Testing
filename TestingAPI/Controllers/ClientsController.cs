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
    public class ClientsController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        ClientFactory _clientFactory;
        public ClientsController()
        {
            _clientFactory = new ClientFactory();
        }

        [Route("api/Clients/{client}")]
        public IEnumerable<ClientModel> UserLogin(ClientModel client)
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetLoginData(client).ToList().Select(c => _clientFactory.Create(c));
        }

        // GET: api/Clients        
        public IEnumerable<ClientModel> GetClients()
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllClients().ToList().Select(c => _clientFactory.Create(c));
        }

        // GET: api/Clients/5        
        [Route("api/Clients/{id}")]
        public IEnumerable<ClientModel> GetClient(int id)
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetAllClients(id).ToList().Select(c => _clientFactory.Create(c));
        }        

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(Client client)
        {
            int id = client.ClientId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClientId)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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


        //public Client userLogin(Client c)
        //{

        //    var userInfo = db.Clients.FirstOrDefault(data => data.Email.Equals(c.Email) && data.Password.Equals(c.Password));

        //    return userInfo;
        //}

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [Route("api/Clients/{id}")]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.ClientId == id) > 0;
        }
    }
}