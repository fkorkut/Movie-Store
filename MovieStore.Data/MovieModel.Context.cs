﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieStore.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MovieStoreEntities : DbContext
    {
        public MovieStoreEntities()
            : base("name=MovieStoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<MovieActor> MovieActors { get; set; }
        public virtual DbSet<Movy> Movies { get; set; }
        public virtual DbSet<RecordStatus> RecordStatuses { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
