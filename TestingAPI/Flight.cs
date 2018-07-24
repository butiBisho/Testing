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
    
    public partial class Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            this.Client_Flight = new HashSet<Client_Flight>();
        }
    
        public int FlightId { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public string Stops { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> AirL_ID { get; set; }
        public Nullable<System.DateTime> FlightDate { get; set; }
        public Nullable<int> AdminID { get; set; }
        public Nullable<int> TotalSeats { get; set; }
        public Nullable<int> SeatsLeft { get; set; }
    
        public virtual Airline Airline { get; set; }
        public virtual Administrator Administrator { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client_Flight> Client_Flight { get; set; }
    }
}
