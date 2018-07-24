using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class ClientModel
    {
        public int ClientId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<DriverModel> Driver { get; set; }
        public IEnumerable<PartnerModel> Partner { get; set; }
        public IEnumerable<TravellerModel> Traveller { get; set; }
        public IEnumerable<ClientCarModel> Client_Car { get; set; }
        public IEnumerable<ClientFlightModel> Client_Flight { get; set; }
        public IEnumerable<ClientHotelModel> Client_Hotel { get; set; }

        public IEnumerable<CarPaymentModel> CarPayment { get; set; }
        public IEnumerable<FlightPaymentModel> FlightPayment { get; set; }
        public IEnumerable<HotelPaymentModel> HotelPayment { get; set; }
    }
}