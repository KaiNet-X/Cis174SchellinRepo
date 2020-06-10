using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCentral.Areas.Movies.Models
{
    public class GenreModel
    {
        [Key]
        public string GenreID { get; set; }
        public string Name { get; set; }
    }
}
