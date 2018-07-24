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
    
    public partial class Client_Hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client_Hotel()
        {
            this.HotelPayments = new HashSet<HotelPayment>();
        }
    
        public int CH_Id { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string Status { get; set; }
        public Nullable<double> TotalCost { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> HotelId { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Hotel Hotel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelPayment> HotelPayments { get; set; }
    }
}