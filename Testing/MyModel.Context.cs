﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Testing
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BootCampEntities : DbContext
    {
        public BootCampEntities()
            : base("name=BootCampEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Traveller> Travellers { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<UploadedFile> UploadedFiles { get; set; }
        public virtual DbSet<RoomImage> RoomImages { get; set; }
        public virtual DbSet<CarImage> CarImages { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
    }
}
