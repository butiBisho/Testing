using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models.test
{
    public class TravellerViewModel
    {
        public int TravellerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public Nullable<int> ClientId { get; set; }

        public ClientViewModel Client { get; set; }
    }
}