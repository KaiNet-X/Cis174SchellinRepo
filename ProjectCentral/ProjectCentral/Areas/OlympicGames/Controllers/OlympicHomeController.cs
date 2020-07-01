using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using ProjectCentral.Areas.OlympicGames.Models;
using ProjectCentral.Areas.OlympicGames.Models.Session;
using ProjectCentral.Areas.OlympicGames.Models.ViewModels;

namespace ProjectCentral.Areas.OlympicGames.Controllers
{
    [Area("OlympicGames")]

    public class OlympicHomeController : Controller
    {
        private OlympicContext Context;
        //sets context
        public OlympicHomeController(OlympicContext context)
        {
            Context = context;
        }

        [Route("{area:exists}/{controller}/{action}/{category?}/{game?}")]
        //inserts all for games and category, filters list of games based on these
        public IActionResult Home(string category = "All", string game = "All")
        {
            FavoritesSessionModel favorites = new FavoritesSessionModel(HttpContext.Session);
            ViewBag.Favorites = favorites.GetFavorites();

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

        [Route("{area:exists}/{controller}/{action}/{countryname?}")]
        [HttpGet]
        /*
         * gets country instance by passing route parameter name, assigns it to viewmodel,
         * determins if it is already a favorite
         */
        public IActionResult Detail(string countryname)
        {
            FavoritesSessionModel favorites = new FavoritesSessionModel(HttpContext.Session);

            Country country = Context.Countries.Include(c => c.Sport).Include(c => c.Sport.Category).Include(c => c.Game)
                .SingleOrDefault(c => c.CountryName.ToLower() == countryname.ToLower());

            CountryViewModel model = new CountryViewModel()
            { country = country, Favorite = favorites.IsFavorite(country), Favorites = favorites.GetFavorites() };

            return View(model);
        }
        //adds country to favorites in session, redirects back to details get
        [HttpPost]
        public IActionResult Detail(CountryViewModel model)
        {
            FavoritesSessionModel favorites = new FavoritesSessionModel(HttpContext.Session);
            List<Country> Favorites = favorites.GetFavorites();

            Country country = Context.Countries.Include(c => c.Sport).Include(c => c.Sport.Category).Include(c => c.Game)
                .FirstOrDefault(c => c.CountryID == model.country.CountryID);
            if (Favorites != null)
            {
                if (Favorites.Find(c => c.CountryID == model.country.CountryID) == null)
                {
                    Favorites.Add(country);
                    favorites.SetFavorites(Favorites);
                }
            }
            else
            {
                Favorites = new List<Country>();
                Favorites.Add(country);
                favorites.SetFavorites(Favorites);
            }
            RouteValueDictionary values = new RouteValueDictionary()
            { { "countryname", country.CountryName  } };
            return RedirectToAction("Detail","OlympicHome", values);
        }
    }
}
