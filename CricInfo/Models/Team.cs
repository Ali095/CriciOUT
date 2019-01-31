using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CricInfo.Models
{
    public class Team
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Captain { get; set; }
        public int MatchPlayed { get; set; }
        
        public int MatchWin { get; set; }
        
        public int MatchLoose { get; set; }
        
        public int MatchTie { get; set; }
        public ICollection<Player> Players { get; set; }
        public string Owner { get; set; }
        [ForeignKey("Owner")]
        public virtual ApplicationUser UserRef { get; set; }

        public Team()
        {
            
        }

        public Team(int id, string name, string[] players, string captain, int matchPlayed, int matchWin, int matchLoose, int matchTie)
        {
            
            Id = id;
            Captain = captain ?? throw new ArgumentNullException(nameof(captain));
            MatchPlayed = matchPlayed;
            MatchWin = matchWin;
            MatchLoose = matchLoose;
            MatchTie = matchTie;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
