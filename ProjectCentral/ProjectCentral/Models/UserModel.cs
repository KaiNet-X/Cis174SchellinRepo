using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCentral.Models
{
    public class UserModel
    {
        [Required]
        [Key]
        public uint? UserID { get; set; }
        [Required(ErrorMessage = "Please enter a user name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int RoleID { get; set; }
        public RoleAuthorizationModel Role { get; set; }
    }
}
