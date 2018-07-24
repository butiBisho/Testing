using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingAPI.Models;

namespace TestingAPI.Controllers
{
    public class PartFourController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        AdminFactory _adminFactory;
        public PartFourController()
        {
            _adminFactory = new AdminFactory();
        }

        [Route("api/PartFour/{id}")]
        public IEnumerable<SupplierModel> GetSuppliersByAdminId(int id)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetSupplierByAdminId(id).ToList().Select(c => _adminFactory.Create(c));
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
