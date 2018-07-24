using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingAPI.Models;

namespace TestingAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        AdminFactory _adminFactory;
        public ValuesController()
        {
            _adminFactory = new AdminFactory();
        }

        [Route("api/Values/{city}")]
        public IEnumerable<HotelModel> GetAllHotels(string city)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllHotelsByCity(city).ToList().Select(c => _adminFactory.Create(c));
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
