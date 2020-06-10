using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
