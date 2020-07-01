using System.Collections.Generic;

namespace ProjectCentral.Areas.OlympicGames.Models.ViewModels
{
    public class CountryViewModel
    {
        public Country country { get; set; }
        public List<Country> Favorites { get; set; }
        public bool Favorite { get; set; }
    }
}
