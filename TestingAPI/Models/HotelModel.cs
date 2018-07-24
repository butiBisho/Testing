using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class HotelModel
    {
        public int HotelID { get; set; }
        public string Name { get; set; }
        public string TelNumber { get; set; }        
        public int StarRating { get; set; }
        public int NumberOfRooms { get; set; }
        public int LocationId { get; set; }
        public int AdminID { get; set; }
        public int RoomsLeft { get; set; }

        public IEnumerable<RoomModel> Room { get; set; }
        public IEnumerable<ClientHotelModel> Client_Hotel { get; set; }
        
        public string Destination { get; set; }
        public string StreetName { get; set; }
        public string Code { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
    }
}