using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TruckDriverApp.ViewModels
{
    public class CommentReviewViewModel
    {
        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your comments regarding this facility")]
        [Display(Name = "Facility Comments")]
        public string FacilityComments { get; set; }

        [Required(ErrorMessage = "Have any images to add to this facility?")]
        [Display(Name = "Facility picture")]

        public IFormFile FacilityPicture { get; set; }
    }
}
