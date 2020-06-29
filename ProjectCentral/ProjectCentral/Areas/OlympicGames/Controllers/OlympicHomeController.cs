using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCentral.Areas.OlympicGames.Models;

namespace ProjectCentral.Areas.OlympicGames.Controllers
{
    [Area("OlympicGames")]
    [Route("{area:exists}/{controller}/{action}/{category?}/{game?}")]
    public class OlympicHomeController : Controller
    {
        private OlympicContext Context;
        //sets context
        public OlympicHomeController(OlympicContext context)
        {
            Context = context;
        }
        //inserts all for games and category, filters list of games based on these
        public IActionResult Home(string category = "All", string game = "All")
        {
            List<Game> Games = Context.Games.ToList();
            Games.Insert(0, new Game { GameName = "All" });
            ViewBag.Games = Games;
            ViewBag.ActiveGame = game;

            List<Category> Categories = Context.Categories.ToList();
            Categories.Insert(0, new Category { CategoryName = "All" });
            ViewBag.Categories = Categories;
            ViewBag.ActiveCategory = category;

            List<Country> countries;
            if (category.ToLower() != "all")
            {
                if (game.ToLower() != "all")
                {
                    countries = Context.Countries.Include(c => c.Game)
                        .Include(c => c.Sport).Include(c => c.Sport.Category).OrderBy(c => c.CountryName)
                        .Where(c => c.Game.GameName.ToLower() == game.ToLower())
                        .Where(c => c.Sport.Category.CategoryName.ToLower() == category.ToLower()).ToList();
                }
                else
                {
                    countries = Context.Countries.Include(c => c.Game)
                        .Include(c => c.Sport).Include(c => c.Sport.Category).OrderBy(c => c.CountryName)
                        .Where(c => c.Sport.Category.CategoryName.ToLower() == category.ToLower()).ToList();
                }
            }
            else if (game.ToLower() != "all")
            {
                countries = Context.Countries.Include(c => c.Game)
                    .Include(c => c.Sport).Include(c => c.Sport.Category).OrderBy(c => c.CountryName)
                    .Where(c => c.Game.GameName.ToLower() == game.ToLower()).ToList();
            }
            else
            {
                countries = Context.Countries.Include(c => c.Game)
                    .Include(c => c.Sport).Include(c => c.Sport.Category).OrderBy(c => c.CountryName).ToList();
            } 
            return View(countries);
        }
    }
}
