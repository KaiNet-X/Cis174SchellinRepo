using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjectCentral.Areas.Movies.Models;

namespace ProjectCentral.Areas.Movies.Controllers
{
    [Area("Movies")]
    public class MovieController : Controller
    {
        private MovieContextModel context;
        //constructor sets context with dependency injection
        public MovieController(MovieContextModel ctx)
        {
            context = ctx;
        }
        //get method returns edit view, sets action to add and genre property and empty moviemodel
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            return View("Edit", new MovieModel());
        }
        //get method returns edit view with edit action and an existing moviemodel
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            var movie = context.Movies.Find(id);
            return View(movie);
        }
        //edits or adds the movie
        [HttpPost]
        public IActionResult Edit(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieID == 0) context.Movies.Add(movie);
                else context.Movies.Update(movie);
                context.SaveChanges();
                return RedirectToAction("Index", "MovieHome");
            }
            else
            {
                ViewBag.Action = (movie.MovieID == 0) ? "Add" : "Edit";
                ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
                return View(movie);
            }
        }
        //get method returns delete view with movie model passed to it
        [HttpGet]
        public IActionResult Delete(int id)
        {
            MovieModel movie = context.Movies.Find(id);
            return View(movie);
        }
        //post method deletes movie and returns to index view of moviehome
        [HttpPost]
        public IActionResult Delete(MovieModel movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("Index", "MovieHome");
        }
    }
}
