using System.ComponentModel.DataAnnotations;

namespace ProjectCentral.Models
{
    public class RoleAuthorizationModel
    {
        [Required]
        [Key]
        public int? RoleID { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
