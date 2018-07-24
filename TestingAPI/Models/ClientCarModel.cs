using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class ClientCarModel
    {
        public int CC_Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
        public double TotalCost { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }

        public IEnumerable<CarPaymentModel> CarPayment { get; set; }
                
        public string Name { get; set; }
    }
}