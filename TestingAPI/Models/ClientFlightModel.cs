using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class ClientFlightModel
    {
        public int CF_Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
        public int ClientId { get; set; }
        public int FlightId { get; set; }
        public double TotalCost { get; set; }

        public IEnumerable<FlightPaymentModel> FlightPayment { get; set; }

        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
    }
}