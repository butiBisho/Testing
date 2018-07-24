using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class DriverModel
    {
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string FlightNumber { get; set; }
        public int Age { get; set; }
        public int ClientId { get; set; }

        public string ClientName { get; set; }
    }
}