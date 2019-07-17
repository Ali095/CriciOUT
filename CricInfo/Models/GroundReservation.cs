using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CricInfo.Models
{
    public class GroundReservation
    {

        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser UserRef { get; set; }

        [Required]
        public int GroundId { get; set; }
        [ForeignKey("GroundId")]
        public virtual Ground GroundRef { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "Date of Booking can't be Null")]
        [Display(Name = "Date of Booking")]
        public DateTime ReservationDate { get; set; }

    }
}
