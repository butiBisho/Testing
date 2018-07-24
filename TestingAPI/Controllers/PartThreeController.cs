using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingAPI.Models;

namespace TestingAPI.Controllers
{
    public class PartThreeController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        ClientFactory _clientFactory;
        public PartThreeController()
        {
            _clientFactory = new ClientFactory();
        }

        [Route("api/PartThree/{id}")]
        public IEnumerable<PartnerModel> GetAllPartners(int id)
        {
            ClientRepository cr = new ClientRepository();
            return cr.GetPartner(id).ToList().Select(c => _clientFactory.Create(c));
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
