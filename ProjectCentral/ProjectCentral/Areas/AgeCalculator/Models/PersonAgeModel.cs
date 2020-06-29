using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectCentral.Areas.AgeCalculator.Models
{
    public class PersonAgeModel
    {
        //requires name to be entered
        [Required(ErrorMessage = "Please enter a valid name")]
        public string Name { get; set; }
        //enter a birthday without time specified
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter a valid birthday, as well as time. If you do not know the time, just enter any value.")]
        public DateTime? Birthday { get; set; }
        //returns aproxamate age in years as of 2020
        public int? AgeThisYear()
        {
            return 2020 - Birthday.Value.Year;
        }
        //calculates age today with timespan of existing
        public TimeSpan? AgeToday()
        {
            DateTime Today = DateTime.Now;
            return Today - Birthday;
        }
    }
}
