using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingAPI.Models;

namespace TestingAPI.Controllers
{
    public class PersonsController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        ClientFactory _clientFactory;
        public PersonsController()
        {
            _clientFactory = new ClientFactory();
        }

        [Route("api/Persons/{id}")]
        public IEnumerable<TravellerModel> GetAllTravellers(int id)
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetTraveller(id).ToList().Select(c => _clientFactory.Create(c));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
