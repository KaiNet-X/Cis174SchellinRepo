using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectCentral.Areas.Ticketing.Models
{
    public class Ticket
    {
        [Required(ErrorMessage ="You must enter a name for this ticket.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage =
            "Ticket name must be between 5 and 30 charachters long.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="You must add description to this ticket.")]
        [StringLength(300, MinimumLength = 10,
            ErrorMessage ="Description must be between 10 and 300 charachters long.")]
        public string Description { get; set; }
        [Key]
        [Required]
        public int SprintNumber { get; set; }
        [Required(ErrorMessage = "You must enter a point value.")]
        [Range(1,10, ErrorMessage = "Ticket value must be between 1 and 10.")]
        public byte? PointValue { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
