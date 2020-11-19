using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TruckDriverApp.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Display(Name = "Email Address:")]
        public string EmailAddress { get; set; }

        [Display(Name = "Entry Time:")]
        public DateTime EntryTime { get; set; }

        [Display(Name = "Exit Time:")]
        public DateTime ExitTime { get; set; }

        [Display(Name = "Notes:")]
        public string Notes { get; set; }

        [Display(Name = "Rating:")]
        public double Rating { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [ForeignKey("VehicleId")]

        [Display(Name = "Vehicle Id")]
        public int? VehicleId { get; set; }

        [ForeignKey("ProfileId")]

        [Display(Name = "Profile Id")]
        public int? ProfileId { get; set; }

        public Vehicle Vehicle { get; set; }


    }
}
