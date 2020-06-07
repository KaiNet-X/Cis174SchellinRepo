using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectCentral.Models;

namespace ProjectCentral.Controllers
{
    public class MovieController : Controller
    {
        private MovieContextModel context;
        public MovieController(MovieContextModel ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            return View("Edit", new MovieModel());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            var movie = context.Movies.Find(id);
            return View(movie);
        }
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
        [HttpGet]
        public IActionResult Delete(int id)
        {
            MovieModel movie = context.Movies.Find(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(MovieModel movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("Index", "MovieHome");
        }
    }
}
