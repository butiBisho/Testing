using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models.test
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<DriverViewModel> Drivers { get; set; }
        public virtual ICollection<PartnerViewModel> Partners { get; set; }
        public virtual ICollection<TravellerViewModel> Travellers { get; set; }
    }
}