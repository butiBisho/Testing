using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class FlightDetailsModel
    {
        public string AirlineName { get; set; }
        public int AirlineId { get; set; }

        public int FlightId { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public string Stops { get; set; }
        public float Price { get; set; }
        public DateTime FlightDate { get; set; }
    }
}