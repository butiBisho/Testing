using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class ClientHotelModel
    {
        public int CH_Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
        public double TotalCost { get; set; }
        public int ClientId { get; set; }
        public int HotelId { get; set; }

        public IEnumerable<HotelPaymentModel> HotelPayment { get; set; }

        public string Name { get; set; }
    }
}