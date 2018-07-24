using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models.test
{
    public class PartnerViewModel
    {
        public int PartnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> ClientId { get; set; }

        public ClientViewModel Client { get; set; }
    }
}