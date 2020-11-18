using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TruckDriverApp.Models;

namespace TruckDriverApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Id = "1bd87b74-3b02-4126-98e3-b9acb0767fc6",
                ConcurrencyStamp = "d64071ec-a650-4f69-9573-92b09388dc87",
                Name = "Driver",
                NormalizedName = "DRIVER"
            }
            );
            builder.Entity<IdentityRole>()
           .HasData(
           new IdentityRole
           {
               Id = "77e60802-3e18-40cf-8999-79aa642defb1",
               ConcurrencyStamp = "d99bf75f-52c0-4416-ad87-3d7bdf8b449f",
               Name = "Administrator",
               NormalizedName = "ADMINISTRATOR"
           }
           );
        }
        public DbSet<Facility> Facilitys { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
    }
}


