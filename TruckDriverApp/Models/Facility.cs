using System;
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
        [Display(Name = "FacilityId")]
        public int Id { get; set; }

        public string Name { get; set; }
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

        //[Display(Name = "Rating")]
        //public double Rating { get; set; }

        [Display(Name = "Has Drivers Lounge")]
        public bool DriversLounge { get; set; }

        [Display(Name = "Facility Has Showers")]
        public bool HasShowers { get; set; }

        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }

        [ForeignKey("ProfileId")]

        [Display(Name = "Profile Id")]
        public int? ProfileId { get; set; }

        [ForeignKey("Driver Id")]
        public int? DriverId { get; set; }
        [ForeignKey("RateId")]

        public int? RateId { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        public string Rating { get; set; }

        [NotMapped]
        public int? RateCount
        {
            get
            {
                if (ratings == null)
                {
                    return null;
                }
                else
                {
                    return ratings.Count;
                }
            }
        }
        [NotMapped]
        public decimal RateAvg
        {
            get
            {

                if (ratings == null)
                {
                    return 0;
                }
                else
                {
                    return (decimal)(RateTotal / RateCount);
                }

            }
        }

        [NotMapped]
        public int? RateTotal
        {
            get
            {
                if (ratings == null)
                {
                    return null;
                }
                else
                    return (ratings.Sum(m => m.Rate));
            }
        }
        [NotMapped]
        public virtual ICollection<Rating> ratings { get; set; }


    }
}

