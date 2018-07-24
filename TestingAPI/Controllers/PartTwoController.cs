using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingAPI.Models;

namespace TestingAPI.Controllers
{
    public class PartTwoController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        ClientFactory _clientFactory;
        public PartTwoController()
        {
            _clientFactory = new ClientFactory();
        }

        [Route("api/PartTwo/{id}")]
        public IEnumerable<DriverModel> GetAllDrivers(int id)
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetDriver(id).ToList().Select(c => _clientFactory.Create(c));
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
