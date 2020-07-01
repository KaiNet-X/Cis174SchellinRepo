using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectCentral.Areas.OlympicGames.Models;
using ProjectCentral.Areas.OlympicGames.Models.Session;

namespace ProjectCentral.Areas.OlympicGames.Controllers
{
    [Area("OlympicGames")]
    public class FavoritesController : Controller
    {
        [HttpGet]
        //Returns the Favorites view with a list of all the favorites
        public IActionResult Favorites()
        {
            FavoritesSessionModel favorites = new FavoritesSessionModel(HttpContext.Session);
            List<Country> model = favorites.GetFavorites();
            return View(model);
        }
        [HttpPost]
        //clears favorites, accepts boolean just for overloading, returns home
        public IActionResult Favorites(bool f = false)
        {
            FavoritesSessionModel favorites = new FavoritesSessionModel(HttpContext.Session);
            favorites.SetFavorites(null);
            return RedirectToAction("Home", "OlympicHome");
        }
    }
}
