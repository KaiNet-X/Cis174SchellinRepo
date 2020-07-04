using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ProjectCentral.Areas.OlympicGames.Models.ViewModels
{
    public class CountryViewModel
    {
        public Country country { get; set; }
        public List<Country> Countries { get; set; }
        public bool Favorite { get; set; }

        public Category category { get; set; } = new Category { CategoryName = "All" };
        public Game game { get; set; } = new Game { GameName = "All" };
    }
}
