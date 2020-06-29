using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectCentral.Areas.Movies.Models
{
    public class MovieModel
    {
        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Year.ToString();
        [Key]
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
        //associates genre to movie
        public string GenreID { get; set; }
        public GenreModel Genre { get; set; }
    }
}
