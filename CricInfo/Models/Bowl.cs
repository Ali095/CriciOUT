using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricInfo.Models
{
    public class Bowl
    {
        [Key]
        public int id { get; set; }
        public int TotalWickets { get; set; }
        public int Fives { get; set; }
        public int Threes { get; set; }
        public int Hatricks { get; set; }
    }
}
