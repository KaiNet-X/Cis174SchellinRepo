using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjectCentral.Areas.Movies.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectCentral.Areas.Movies.Controllers
{
    [Area("Movies")]
    public class MovieHomeController : Controller
    {
        private MovieContextModel context;
        //sets context
        public MovieHomeController(MovieContextModel ctx)
        {
            context = ctx;
        }
        //returns index view
        public IActionResult Index()
        {
            var movies = context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
            return View(movies);
        }
    }
}
