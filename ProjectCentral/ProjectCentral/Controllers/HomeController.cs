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
            UserModel user = AuthenticationModel.GetSessionUser(HttpContext.Session.Id);
            ViewBag.Username = user.UserName;
            ViewBag.Role = user.Role.RoleName;
            ViewBag.SignedIn = AuthenticationModel.GetSessionUser(HttpContext.Session.Id).RoleID != 3;

            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            UserModel user = AuthenticationModel.GetSessionUser(HttpContext.Session.Id);
            ViewBag.Username = user.UserName;
            ViewBag.Role = user.Role.RoleName;
            return View();
        }
        [HttpPost]
        public IActionResult Logout(byte falsevalue = 0)
        {
            AuthenticationModel.RemoveSessionUser(HttpContext.Session.Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Login()
        {
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
