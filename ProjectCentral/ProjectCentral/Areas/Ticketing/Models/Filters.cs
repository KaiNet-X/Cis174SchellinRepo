using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectCentral.Areas.Ticketing.Models
{
    public class Filters
    {
        //options manually set in partial view
        [Range(1, 10)]
        public byte PointFilter { get; set; } = 1;
        public Status StatFilter { get; set; } = Status.ToDo;
    }
}
