using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TruckDriverApp.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Truck Make")]
        public string TruckMake { get; set; }

        [Display(Name = "Truck Model")]
        public string TruckModel { get; set; }

        [Display(Name = "Truck Year")]
        public int TruckYear { get; set; }

        [Display(Name = "Truck Color")]
        public int TruckColor { get; set; }

        [Display(Name = "Truck License Plate")]
        public int TruckLicensePlate { get; set; }

        [Display(Name = "Truck Notes")]
        public int TruckNotes { get; set; }

        [Display(Name = "Vehicle Id")]
        public int? VehicleId { get; set; }

        [ForeignKey("Driver Id")]
        public int? DriverId { get; set; }
    }
}
