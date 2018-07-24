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
    
    public partial class Room
    {
        public int RoomID { get; set; }
        public string AccommodationType { get; set; }
        public string Facility { get; set; }
        public string Theme { get; set; }
        public string AccessibilityFeatures { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> HotelId { get; set; }
        public Nullable<int> AdminID { get; set; }
        public string RoomNumber { get; set; }
    
        public virtual Hotel Hotel { get; set; }
        public virtual Administrator Administrator { get; set; }
    }
}