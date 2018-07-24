using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class FlightModel
    {
        public int FlightId { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public string Stops { get; set; }
        public float Price { get; set; }
        public int AirL_ID { get; set; }
        public string AirlineName { get; set; }
        public int AdminID { get; set; }
        public int TotalSeats { get; set; }
        public int SeatsLeft { get; set; }
        public string IATA { get; set; }

        public DateTime FlightDate { get; set; }
        public IEnumerable<ClientFlightModel> Client_Flight { get; set; }
    }
}