using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class CarModel
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Mileage { get; set; }
        public double Price { get; set; }
        public string SpecialOffer { get; set; }
        public string CarSpecifications { get; set; }
        public string Transmission { get; set; }
        public int SupplierID { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int AdminID { get; set; }
        public int TotalCars { get; set; }
        public int CarsLeft { get; set; }

        public IEnumerable<ClientCarModel> Client_Car { get; set; }
    }
}