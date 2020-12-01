using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TruckDriverApp.Models
{
    public class Rating
    {
        [Key]
        public int RateId { get; set; }
        public int Rate { get; set; }

        [ForeignKey("FacilityId")]
        public int facilityId { get; set; }
        public virtual Facility facility { get; set; }

    }
}
