using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CricInfo.Models
{
    public class Match
    {
        [Key]
        public int id { get; set; }
        [Required]
        
        public int Ground { get; set; }
        [Display(Name = "Venue")]
        [ForeignKey("Ground")]
        public virtual Ground GroundRef { get; set; }
        [Required]
        public int TotalOvers { get; set; }
        public double CurrentOver { get; set; }
        public Player Striker { get; set; }
        public Player NonStriker { get; set; }
        public Player Bowler { get; set; }
        public int CurrentScore { get; set; }
        public int CurrentWickets { get; set; }

        [Required]
        [Display(Name ="Batting Team")]
        public  int TeamA { get; set; }
        [ForeignKey("TeamA")]
        public virtual Team BatTeam { get; set; }

        [Required]
        [Display(Name = "Bowling Team")]
        public  int? TeamB { get; set; }
        [ForeignKey("TeamB")]
        public virtual Team BowlTeam { get; set; }

        public Player ManoftheMatch { get; set; }

        public string Result { get; set; }

        public int Umpire1 { get; set; }
        [ForeignKey("Umpire1")]
        public virtual Umpire UmpireRef { get; set; }

        public int?  Umpire2 { get; set; }
        [ForeignKey("Umpire2")]
        public virtual Umpire UmpireRef2 { get; set; }
    }

    
}
