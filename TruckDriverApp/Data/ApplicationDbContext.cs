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
                Name = "Driver",
                NormalizedName = "DRIVER"
            }
            );
            builder.Entity<IdentityRole>()
           .HasData(
           new IdentityRole
           {
       
               Name = "Administrator",
               NormalizedName = "ADMINISTRATOR"
           }
           );
        }
        public DbSet<Facility> Facilitys { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<CommentReview> CommentReviews { get; set; }
    }
}


