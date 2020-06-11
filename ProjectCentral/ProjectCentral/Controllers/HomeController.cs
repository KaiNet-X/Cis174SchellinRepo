using Microsoft.AspNetCore.Mvc;
using ProjectCentral.Models;
using Microsoft.AspNetCore.Http;

namespace ProjectCentral.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(UserContextModel context)
        {
            AuthenticationModel.UserContext = context;
        }
        public IActionResult Index()
        {
            if (AuthenticationModel.GetSessionUser(HttpContext.Session.Id) != null) 
            {
                UserModel user = AuthenticationModel.GetSessionUser(HttpContext.Session.Id);
                ViewBag.Username = user.UserName;
                ViewBag.Role = user.Role.RoleName;
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (AuthenticationModel.GetSessionUser(HttpContext.Session.Id) != null) return RedirectToAction("Index");
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserModel User)
        {
            if (AuthenticationModel.UserInfoCorrect(User))
            {
                UserModel DbUser = AuthenticationModel.DatabaseAccurateUser(User);
                AuthenticationModel.AddSessionUser(DbUser, HttpContext.Session.Id);
                HttpContext.Session.SetString(" ", " ");
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            if (AuthenticationModel.GetSessionUser(HttpContext.Session.Id) != null) return RedirectToAction("Index");
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserModel User)
        {
            if (AuthenticationModel.RegisterUser(User))
            {
                UserModel DbUser = AuthenticationModel.DatabaseAccurateUser(User);
                AuthenticationModel.AddSessionUser(DbUser, HttpContext.Session.Id);
                HttpContext.Session.SetString(" ", " ");
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
