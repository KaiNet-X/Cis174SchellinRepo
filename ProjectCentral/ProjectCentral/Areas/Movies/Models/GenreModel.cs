using System.ComponentModel.DataAnnotations;

namespace ProjectCentral.Areas.Movies.Models
{
    public class GenreModel
    {
        [Key]
        public string GenreID { get; set; }
        public string Name { get; set; }
    }
}
