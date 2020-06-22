using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCentral.Areas.OlympicGames.Models
{
    public class Sport
    {
        public int SportID { get; set; }
        public string SportName { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
