using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCentral.Areas.Ticketing.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter a username")]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Username must be from 3 to 16 charachters")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password and Confirm password must match")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter a confirm password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
