﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TruckDriverApp.Models
{
    public class Facility
    {
        [Key]
        [Display(Name = "Facility Id")]
        public int ID { get; set; }
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Phone Number")]
        public double PhoneNumber { get; set; }

        [Display(Name = "Overnight Parking Available")]
        public bool OvernightParking { get; set; }

        [ForeignKey("Driver Id")]
        public int? DriverId { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [Display(Name = "Parking Options")]
        public string ParkingOptions { get; set; }

        [Display(Name = "Food Delivery")]
        public string FoodDelivery { get; set; }

        [Display(Name = "Other Options")]
        public string OtherOptions { get; set; }

        [Display(Name = "Rating")]
        public double Rating { get; set; }

        [Display(Name = "Has Drivers Lounge")]
        public bool DriversLounge { get; set; }

        [Display(Name = "Facility Has Showers")]
        public bool HasShowers { get; set; }

        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
    }
}
