﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectMaleabAlKorbV2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MalaebAlKorbEntities : DbContext
    {
        public MalaebAlKorbEntities()
            : base("name=MalaebAlKorbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<playerDeleteData> playerDeleteDatas { get; set; }
        public virtual DbSet<playerUpdateData> playerUpdateDatas { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Stadium> Stadia { get; set; }
        public virtual DbSet<stadiumDeleteData> stadiumDeleteDatas { get; set; }
        public virtual DbSet<stadiumUpdateData> stadiumUpdateDatas { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
    }
}
