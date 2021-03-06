﻿using Microsoft.EntityFrameworkCore;

namespace ProjectCentral.Areas.Movies.Models
{
    public class MovieContextModel : DbContext
    {
        //passes options to baseclass
        public MovieContextModel(DbContextOptions<MovieContextModel> options)
            : base(options)
        { }

        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<GenreModel> Genres { get; set; }
        //seeds initial moviedata
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GenreModel>().HasData(
                new GenreModel { GenreID = "A", Name = "Action" },
                new GenreModel { GenreID = "C", Name = "Comedy" },
                new GenreModel { GenreID = "D", Name = "Drama" },
                new GenreModel { GenreID = "H", Name = "Horror" },
                new GenreModel { GenreID = "M", Name = "Musical" },
                new GenreModel { GenreID = "R", Name = "RomCom" },
                new GenreModel { GenreID = "S", Name = "SciFi" }
                );

            modelBuilder.Entity<MovieModel>().HasData
            (
                new MovieModel
                {
                    MovieID = 1,
                    Name = "Cassablanca",
                    Year = 1942,
                    Rating = 5,
                    GenreID = "D"
                },
                new MovieModel
                {
                    MovieID = 2,
                    Name = "Wonder Woman",
                    Year = 2017,
                    Rating = 3,
                    GenreID = "A"
                },
                new MovieModel
                {
                    MovieID = 3,
                    Name = "Moonstruck",
                    Year = 1988,
                    Rating = 4,
                    GenreID = "R"
                }
            );
        }
    }
}
