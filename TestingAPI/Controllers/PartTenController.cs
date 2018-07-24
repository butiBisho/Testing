using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingAPI.Models;

namespace TestingAPI.Controllers
{
    public class PartTenController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        AdminFactory _adminFactory;
        public PartTenController()
        {
            _adminFactory = new AdminFactory();
        }

        [Route("api/PartTen/{id}")]
        public IEnumerable<ResidenceModel> GetResidencesByAdminId(int id)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetResidencesByAdminId(id).ToList().Select(c => _adminFactory.Create(c));
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
