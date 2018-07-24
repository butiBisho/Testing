using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingAPI.Models;

namespace TestingAPI.Controllers
{
    public class FlatsController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        AdminFactory _adminFactory;
        public FlatsController()
        {
            _adminFactory = new AdminFactory();
        }

        [Route("api/Flats/{hotelName}")]
        public IEnumerable<RoomModel> GetAllRooms(string hotelName)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllRoomsByHotelName(hotelName).ToList().Select(c => _adminFactory.Create(c));
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
