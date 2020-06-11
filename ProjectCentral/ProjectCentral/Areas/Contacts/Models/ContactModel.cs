using System.ComponentModel.DataAnnotations;

namespace ProjectCentral.Areas.Contacts.Models
{
    public class ContactModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
    }
}
