using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectCentral.Areas.Ticketing.Models
{
    public class Ticket
    {
        [Required(ErrorMessage ="Please enter a name for this ticket.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Key]
        [Required]
        public int SprintNumber { get; set; }
        [Required]
        [Range(1,10, ErrorMessage = "Point value must be between 1 and 10.")]
        public byte PointValue { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
