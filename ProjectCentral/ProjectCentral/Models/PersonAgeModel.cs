using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectCentral.Models
{
    public class PersonAgeModel
    {
        [Required(ErrorMessage = "Please enter a valid name")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Please enter a valid age")]
        //[Range(1890, 2020, ErrorMessage = "How are you even alive?")]
        //public int? BirthYear { get; set; }
        [Required(ErrorMessage = "Please enter a valid birthday, as well as time. If you do not know the time, just enter any value.")]
        public DateTime? Birthday { get; set; }
        public int? AgeThisYear()
        {
            return 2020 - Birthday.Value.Year;
        }
        public TimeSpan? AgeToday()
        {
            DateTime Today = DateTime.Now;
            return Today - Birthday;
        }
    }
}
