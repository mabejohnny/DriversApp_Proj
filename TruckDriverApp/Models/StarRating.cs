using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TruckDriverApp.Models
{
    public class StarRating
    {
        [Key]
        public int RateId { get; set; }
        public int Rate { get; set; }
        public string IpAddress { get; set; }
        public int Id { get; set; }
        [ForeignKey("Facility Id")]
        public virtual Facility Facility { get; set; }
    }
}
