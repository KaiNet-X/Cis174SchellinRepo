using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectCentral.Models
{
    public class Movie
    {
        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Year.ToString();
        public int MovieID { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter publication date.")]
        [Range(1889, 2020, ErrorMessage = "Date out of range.")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 5, ErrorMessage = "Invald rating.")]
        public int? Rating { get; set; }
        [Required(ErrorMessage = "Please enter a genre.")]
        public string GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
