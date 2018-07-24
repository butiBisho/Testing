using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingAPI.Models;

namespace TestingAPI.Controllers
{
    public class PartTwelveController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        AdminFactory _adminFactory;
        public PartTwelveController()
        {
            _adminFactory = new AdminFactory();
        }

        [Route("api/PartTwelve/{id}")]
        public IEnumerable<RoomModel> GetRoomsByAdminId(int id)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetRoomsByAdminId(id).ToList().Select(c => _adminFactory.Create(c));
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
