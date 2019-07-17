using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricInfo.Models
{
    public class Umpire
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(20.0,60.0,ErrorMessage ="Umpire Age should be in range between 20 - 60")]
        public int Age { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        [Display(Name ="T20 Experience")]
        [Range(1.0,150.0,ErrorMessage ="Unexplained Experience")]
        public int Experience { get; set; }
        [Required]
        [Display(Name ="One Day Experience")]
        [Range(1.0,250.0,ErrorMessage ="Unexplained Experience")]
        public int ProExperience { get; set; }
        [Required]
        [Display(Name ="Is Available")]
        public bool Availability { get; set; }

    }
}
