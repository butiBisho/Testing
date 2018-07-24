using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class FlightPaymentModel
    {
        public int FlightPaymentId { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string CVV { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ContactNumber { get; set; }
        public int ClientId { get; set; }
        public int CF_Id { get; set; }
    }
}