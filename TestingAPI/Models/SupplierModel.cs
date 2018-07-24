using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class SupplierModel
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public int AdminID { get; set; }

        public IEnumerable<CarModel> Car { get; set; }
    }
}