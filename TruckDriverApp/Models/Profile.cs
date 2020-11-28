using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TruckDriverApp.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please choose gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter position")]
        public string Position { get; set; }

        [Required(ErrorMessage = "About Me: ")]
        [Display(Name = "About Me")]
        public string AboutMe { get; set; }

        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Photo")]
        public string ProfilePicture { get; set; }

        public Profile()
        {
            FullName = FirstName + " " + LastName;
        }
    }
}
