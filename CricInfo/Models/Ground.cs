using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricInfo.Models
{
    public class Ground
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string  Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string contact { get; set; }
        public bool Availabity { get; set; }

        [Display(Name ="Location URL")]
        public string Location { get; set; }
    }
}
