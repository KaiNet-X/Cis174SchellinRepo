﻿using System.ComponentModel.DataAnnotations;

namespace ProjectCentral.Models
{
    public class UserModel
    {
        [Required]
        [Key]
        public int? UserID { get; set; }
        [Required(ErrorMessage = "Please enter a user name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //associates role with user
        public int RoleID { get; set; }
        public RoleAuthorizationModel Role { get; set; }
    }
}
