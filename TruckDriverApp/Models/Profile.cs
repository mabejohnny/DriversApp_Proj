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

        [Display(Name = "Rating")]
        public string Rating { get; set; }
       
        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "Reviews")]
        public string Reviews { get; set; }
    }
}
