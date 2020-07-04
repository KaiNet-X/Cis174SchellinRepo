using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectCentral.Areas.Ticketing.Models
{
    public class Filters
    {
        [Range(1, 10)]
        public byte PointFilter { get; set; } = 1;
        public Status StatFilter { get; set; } = Status.ToDo;
    }
}
