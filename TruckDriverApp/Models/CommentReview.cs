using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TruckDriverApp.Models
{
    public class CommentReview
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        [StringLength(100)]
        public string? LastName { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Please enter your comments regarding this facility")]
        [Display(Name = "Facility Comments")]
        [StringLength(100)]
        public string? FacilityComments { get; set; }

        [Required(ErrorMessage = "Please enter anything you think should be added to this facilitys profile page")]
        [Display(Name = "What should we add?")]
        [StringLength(100)]
        public string? AddToFacility { get; set; }

        [Required(ErrorMessage = "Have any images to add to this facility?")]
        public string? FacilityPicture { get; set; }


        public CommentReview()
        {
            FullName = FirstName + " " + LastName;
        }
    }
}

