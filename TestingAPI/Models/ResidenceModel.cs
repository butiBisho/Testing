using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class ResidenceModel
    {
        public int LocationID { get; set; }
        public string StreetName { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public int AdminID { get; set; }

        public virtual IEnumerable<HotelModel> Hotel { get; set; }
    }
}