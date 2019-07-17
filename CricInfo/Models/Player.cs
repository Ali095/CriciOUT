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
        public PlayerType role { get; set; }
       
        [Required]
        public int MatchesPlayed { get; set; }
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team TeamRef { get; set; }
        public int? ScoreId { get; set; }
        [ForeignKey("ScoreId")]
        public virtual Score Score { get; set; }
        public int? BowlId { get; set; }
        [ForeignKey("BowlId")]
        public virtual Bowl Bowl { get; set; }

        public string HowOut { get; set; }

        public string OutBy { get; set; }

    }
    public enum PlayerType
    {
        Batsman, Bowler, AllRounder
    }
}
