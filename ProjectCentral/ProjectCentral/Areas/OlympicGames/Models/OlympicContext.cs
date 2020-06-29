using Microsoft.EntityFrameworkCore;

namespace ProjectCentral.Areas.OlympicGames.Models
{
    public class OlympicContext : DbContext
    {
        //passes options to the base constructor
        public OlympicContext(DbContextOptions<OlympicContext> Options)
            :base(Options)
        { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Category> Categories { get; set; }

        //seeds initial data for all database entity tables
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData
                (
                new Category { CategoryName = "Indoor", CategoryID = 1 },
                new Category { CategoryName = "Outdoor", CategoryID = 2 }
                );
            builder.Entity<Game>().HasData
                (
                new Game { GameName = "Winter Olympics", GameID = 1 },
                new Game { GameName = "Summer Olympics", GameID = 2 },
                new Game { GameName = "Paralympics", GameID = 3 },
                new Game { GameName = "Youth Olympic Games", GameID = 4 }
                );
            builder.Entity<Sport>().HasData
                (
                new Sport { SportName = "Curling", SportID = 1, CategoryID = 1 },
                new Sport { SportName = "Bobsleigh", SportID = 2, CategoryID = 2 },
                new Sport { SportName = "Diving", SportID = 3, CategoryID = 1 },
                new Sport { SportName = "Road Cycling", SportID = 4, CategoryID = 2 },
                new Sport { SportName = "Archery", SportID = 5, CategoryID = 1 },
                new Sport { SportName = "Canoe Sprint", SportID = 6, CategoryID = 2 },
                new Sport { SportName = "Breakdancing", SportID = 7, CategoryID = 1 },
                new Sport { SportName = "Skateboarding", SportID = 8, CategoryID = 2 }
                );
            builder.Entity<Country>().HasData
                (
                new Country
                {
                    CountryName = "Canada",
                    CountryID = 1,
                    GameID = 1,
                    SportID = 1
                },
                new Country
                {
                    CountryName = "Sweden",
                    CountryID = 2,
                    GameID = 1,
                    SportID = 1
                }, 
                new Country
                {
                    CountryName = "Great Britain",
                    CountryID = 3,
                    GameID = 1,
                    SportID = 1
                }, 
                new Country
                {
                    CountryName = "Jamaica",
                    CountryID = 4,
                    GameID = 1,
                    SportID = 2
                }, 
                new Country
                {
                    CountryName = "Italy",
                    CountryID = 5,
                    GameID = 1,
                    SportID = 2
                }, 
                new Country
                {
                    CountryName = "Japan",
                    CountryID = 6,
                    GameID = 1,
                    SportID = 2
                },
                new Country
                {
                    CountryName = "Germany",
                    CountryID = 7,
                    GameID = 2,
                    SportID = 3
                }, 
                new Country
                {
                    CountryName = "China",
                    CountryID = 8,
                    GameID = 2,
                    SportID = 3
                }, 
                new Country
                {
                    CountryName = "Mexico",
                    CountryID = 9,
                    GameID = 2,
                    SportID = 3
                },
                new Country
                {
                    CountryName = "Brazil",
                    CountryID = 10,
                    GameID = 2,
                    SportID = 4
                },
                new Country
                {
                    CountryName = "Netherlands",
                    CountryID = 11,
                    GameID = 2,
                    SportID = 4
                },
                new Country
                {
                    CountryName = "USA",
                    CountryID = 12,
                    GameID = 2,
                    SportID = 4
                },
                new Country
                {
                    CountryName = "Thailand",
                    CountryID = 13,
                    GameID = 3,
                    SportID = 5
                },
                new Country
                {
                    CountryName = "Uruguay",
                    CountryID = 14,
                    GameID = 3,
                    SportID = 5
                },
                new Country
                {
                    CountryName = "Ukraine",
                    CountryID = 15,
                    GameID = 3,
                    SportID = 5
                },
                new Country
                {
                    CountryName = "Austria",
                    CountryID = 16,
                    GameID = 3,
                    SportID = 6
                },
                new Country
                {
                    CountryName = "Pakistan",
                    CountryID = 17,
                    GameID = 3,
                    SportID = 6
                },
                new Country
                {
                    CountryName = "Zimbabwe",
                    CountryID = 18,
                    GameID = 3,
                    SportID = 6
                },
                new Country
                {
                    CountryName = "France",
                    CountryID = 19,
                    GameID = 4,
                    SportID = 7
                },
                new Country
                {
                    CountryName = "Cyprus",
                    CountryID = 20,
                    GameID = 4,
                    SportID = 7
                },
                new Country
                {
                    CountryName = "Russia",
                    CountryID = 21,
                    GameID = 4,
                    SportID = 7
                },
                new Country
                {
                    CountryName = "Finland",
                    CountryID = 22,
                    GameID = 4,
                    SportID = 8
                },
                new Country
                {
                    CountryName = "Slovakia",
                    CountryID = 23,
                    GameID = 4,
                    SportID = 8
                },
                new Country
                {
                    CountryName = "Portugal",
                    CountryID = 24,
                    GameID = 4,
                    SportID = 8
                }
                );
        }
    }
}
