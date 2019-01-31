using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CricInfo.Models
{
    public class Player
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ShirtNumber { get; set; }
        [Required]
        public int MatchesPlayed { get; set; }
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team TeamRef { get; set; }
    }
}
