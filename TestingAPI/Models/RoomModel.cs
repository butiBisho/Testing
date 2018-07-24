using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class RoomModel
    {
        public int RoomID { get; set; }
        public string AccommodationType { get; set; }
        public string Facility { get; set; }
        public string Theme { get; set; }
        public string AccessibilityFeatures { get; set; }        
        public double Price { get; set; }
        public int HotelId { get; set; }        
        public string HotelName { get; set; }
        public int AdminID { get; set; }
        public string RoomNumber { get; set; }

    }
}