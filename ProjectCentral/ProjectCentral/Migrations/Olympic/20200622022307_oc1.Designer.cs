﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectCentral.Areas.OlympicGames.Models;

namespace ProjectCentral.Migrations.Olympic
{
    [DbContext(typeof(OlympicContext))]
    [Migration("20200622022307_oc1")]
    partial class oc1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectCentral.Areas.OlympicGames.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Indoor"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Outdoor"
                        });
                });

            modelBuilder.Entity("ProjectCentral.Areas.OlympicGames.Models.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<int>("SportID")
                        .HasColumnType("int");

                    b.HasKey("CountryID");

                    b.HasIndex("GameID");

                    b.HasIndex("SportID");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryID = 1,
                            CountryName = "Canada",
                            GameID = 1,
                            SportID = 1
                        },
                        new
                        {
                            CountryID = 2,
                            CountryName = "Sweden",
                            GameID = 1,
                            SportID = 1
                        },
                        new
                        {
                            CountryID = 3,
                            CountryName = "Great Britain",
                            GameID = 1,
                            SportID = 1
                        },
                        new
                        {
                            CountryID = 4,
                            CountryName = "Jamaica",
                            GameID = 1,
                            SportID = 2
                        },
                        new
                        {
                            CountryID = 5,
                            CountryName = "Italy",
                            GameID = 1,
                            SportID = 2
                        },
                        new
                        {
                            CountryID = 6,
                            CountryName = "Japan",
                            GameID = 1,
                            SportID = 2
                        },
                        new
                        {
                            CountryID = 7,
                            CountryName = "Germany",
                            GameID = 2,
                            SportID = 3
                        },
                        new
                        {
                            CountryID = 8,
                            CountryName = "China",
                            GameID = 2,
                            SportID = 3
                        },
                        new
                        {
                            CountryID = 9,
                            CountryName = "Mexico",
                            GameID = 2,
                            SportID = 3
                        },
                        new
                        {
                            CountryID = 10,
                            CountryName = "Brazil",
                            GameID = 2,
                            SportID = 4
                        },
                        new
                        {
                            CountryID = 11,
                            CountryName = "Netherlands",
                            GameID = 2,
                            SportID = 4
                        },
                        new
                        {
                            CountryID = 12,
                            CountryName = "USA",
                            GameID = 2,
                            SportID = 4
                        },
                        new
                        {
                            CountryID = 13,
                            CountryName = "Thailand",
                            GameID = 3,
                            SportID = 5
                        },
                        new
                        {
                            CountryID = 14,
                            CountryName = "Uruguay",
                            GameID = 3,
                            SportID = 5
                        },
                        new
                        {
                            CountryID = 15,
                            CountryName = "Ukraine",
                            GameID = 3,
                            SportID = 5
                        },
                        new
                        {
                            CountryID = 16,
                            CountryName = "Austria",
                            GameID = 3,
                            SportID = 6
                        },
                        new
                        {
                            CountryID = 17,
                            CountryName = "Pakistan",
                            GameID = 3,
                            SportID = 6
                        },
                        new
                        {
                            CountryID = 18,
                            CountryName = "Zimbabwe",
                            GameID = 3,
                            SportID = 6
                        },
                        new
                        {
                            CountryID = 19,
                            CountryName = "France",
                            GameID = 4,
                            SportID = 7
                        },
                        new
                        {
                            CountryID = 20,
                            CountryName = "Cyprus",
                            GameID = 4,
                            SportID = 7
                        },
                        new
                        {
                            CountryID = 21,
                            CountryName = "Russia",
                            GameID = 4,
                            SportID = 7
                        },
                        new
                        {
                            CountryID = 22,
                            CountryName = "Finland",
                            GameID = 4,
                            SportID = 8
                        },
                        new
                        {
                            CountryID = 23,
                            CountryName = "Slovakia",
                            GameID = 4,
                            SportID = 8
                        },
                        new
                        {
                            CountryID = 24,
                            CountryName = "Portugal",
                            GameID = 4,
                            SportID = 8
                        });
                });

            modelBuilder.Entity("ProjectCentral.Areas.OlympicGames.Models.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GameName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameID");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameID = 1,
                            GameName = "Winter Olympics"
                        },
                        new
                        {
                            GameID = 2,
                            GameName = "Summer Olympics"
                        },
                        new
                        {
                            GameID = 3,
                            GameName = "Paralympics"
                        },
                        new
                        {
                            GameID = 4,
                            GameName = "Youth Olympic Games"
                        });
                });

            modelBuilder.Entity("ProjectCentral.Areas.OlympicGames.Models.Sport", b =>
                {
                    b.Property<int>("SportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("SportName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SportID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Sports");

                    b.HasData(
                        new
                        {
                            SportID = 1,
                            CategoryID = 1,
                            SportName = "Curling"
                        },
                        new
                        {
                            SportID = 2,
                            CategoryID = 2,
                            SportName = "Bobsleigh"
                        },
                        new
                        {
                            SportID = 3,
                            CategoryID = 1,
                            SportName = "Diving"
                        },
                        new
                        {
                            SportID = 4,
                            CategoryID = 2,
                            SportName = "Road Cycling"
                        },
                        new
                        {
                            SportID = 5,
                            CategoryID = 1,
                            SportName = "Archery"
                        },
                        new
                        {
                            SportID = 6,
                            CategoryID = 2,
                            SportName = "Canoe Sprint"
                        },
                        new
                        {
                            SportID = 7,
                            CategoryID = 1,
                            SportName = "Breakdancing"
                        },
                        new
                        {
                            SportID = 8,
                            CategoryID = 2,
                            SportName = "Skateboarding"
                        });
                });

            modelBuilder.Entity("ProjectCentral.Areas.OlympicGames.Models.Country", b =>
                {
                    b.HasOne("ProjectCentral.Areas.OlympicGames.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectCentral.Areas.OlympicGames.Models.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectCentral.Areas.OlympicGames.Models.Sport", b =>
                {
                    b.HasOne("ProjectCentral.Areas.OlympicGames.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
