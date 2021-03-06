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
    
    public partial class Client_Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client_Flight()
        {
            this.FlightPayments = new HashSet<FlightPayment>();
        }
    
        public int CF_Id { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string Status { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> FlightId { get; set; }
        public Nullable<double> TotalCost { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Flight Flight { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FlightPayment> FlightPayments { get; set; }
    }
}
