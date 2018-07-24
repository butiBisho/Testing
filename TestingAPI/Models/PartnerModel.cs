using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class PartnerModel
    {
        public int PartnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClientId { get; set; }

        public string ClientName { get; set; }
    }
}