//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestingAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarPayment
    {
        public int PaymentId { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<int> Year { get; set; }
        public string CVV { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ContactNumber { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> CC_Id { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Client_Car Client_Car { get; set; }
    }
}
