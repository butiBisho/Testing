using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class ExtraModel
    {
        public int ExtrasId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int AdminID { get; set; }
    }
}