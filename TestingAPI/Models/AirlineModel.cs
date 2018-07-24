using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class AirlineModel
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string IATA { get; set; }
        public int AdminID { get; set; }

        public IEnumerable<FlightModel> Flight { get; set; }
    }
}