﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntelliTransCentre.Models.DBObjects
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SpartanEntities : DbContext
    {
        public SpartanEntities()
            : base("name=SpartanEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<AccountTransaction> AccountTransactions { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarOwnership> CarOwnerships { get; set; }
        public virtual DbSet<CarPark> CarParks { get; set; }
        public virtual DbSet<CarParkingSpace> CarParkingSpaces { get; set; }
        public virtual DbSet<CarParkRate> CarParkRates { get; set; }
        public virtual DbSet<CarParkType> CarParkTypes { get; set; }
        public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public virtual DbSet<Door> Doors { get; set; }
        public virtual DbSet<DoorType> DoorTypes { get; set; }
        public virtual DbSet<EntryRecord> EntryRecords { get; set; }
        public virtual DbSet<FacilityType> FacilityTypes { get; set; }
        public virtual DbSet<Map> Maps { get; set; }
        public virtual DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public virtual DbSet<ParkingSpaceType> ParkingSpaceTypes { get; set; }
        public virtual DbSet<ParkingSubscription> ParkingSubscriptions { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ManageCarpark> ManageCarparks { get; set; }
        public virtual DbSet<carparkmanagement> carparkmanagements { get; set; }
    }
}
