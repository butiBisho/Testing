using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class AdminModel
    {
        public int AdminId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
                
        public virtual IEnumerable<AirlineModel> Airline { get; set; }        
        public virtual IEnumerable<CarModel> Car { get; set; }       
        public virtual IEnumerable<ExtraModel> Extra { get; set; }      
        public virtual IEnumerable<FlightModel> Flight { get; set; }    
        public virtual IEnumerable<HotelModel> Hotel { get; set; }
        public virtual IEnumerable<LocationModel> Location { get; set; }
        public virtual IEnumerable<ResidenceModel> Residence { get; set; }  
        public virtual IEnumerable<RoomModel> Room { get; set; }
        public virtual IEnumerable<SupplierModel> Supplier { get; set; }
    }
}