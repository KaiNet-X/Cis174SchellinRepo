using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCentral.Areas.OlympicGames.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public int GameID { get; set; }
        public Game Game { get; set; }
        public int SportID { get; set; }
        public Sport Sport { get; set; }
        public string FlagPath { get { return "~/Images/Flags/" + CountryName + ".png"; } }
    }
}
