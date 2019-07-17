using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricInfo.Models
{
    public class Score
    {
        [Key]
        public int id { get; set; }
        public int ScoredTotal { get; set; }
        public int BallsPlayed { get; set; }
        public int Fours { get; set; }
        public int Sixes { get; set; }
        public int BestScore { get; set; }
        public int Fifties { get; set; }
        public int Centuries { get; set; }
        public double Average
        {
            get { return ScoredTotal / Player.MatchesPlayed; }
        }
        public virtual Player Player { get; set; }
    }
}
