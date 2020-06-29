using Microsoft.AspNetCore.Mvc;
using ProjectCentral.Models;
using Microsoft.AspNetCore.Http;

namespace ProjectCentral.Controllers
{
    public class HomeController : Controller
    {
        //sets the static context of authentication model in constructor
        public HomeController(UserContextModel context)
        {
            AuthenticationModel.UserContext = context;
        }
        //home page of the application, uses authentication
        public IActionResult Index()
        {
            UserModel user = AuthenticationModel.GetSessionUser(HttpContext.Session.Id);
            ViewBag.Username = user.UserName;
            ViewBag.Role = user.Role.RoleName;
            ViewBag.SignedIn = AuthenticationModel.GetSessionUser(HttpContext.Session.Id).RoleID != 3;

            return View();
        }
        //get method of logout displays the logout view and redirects home if not signed in
        [HttpGet]
        public IActionResult Logout()
        {
            if (AuthenticationModel.GetSessionUser(HttpContext.Session.Id).Role.RoleName == "Anonymous")
                return RedirectToAction("Index");
            UserModel user = AuthenticationModel.GetSessionUser(HttpContext.Session.Id);
            ViewBag.Username = user.UserName;
            ViewBag.Role = user.Role.RoleName;
            return View();
        }
        //post method of logout removes the user from the list of active users
        [HttpPost]
        public IActionResult Logout(byte falsevalue = 0)
        {
            AuthenticationModel.RemoveSessionUser(HttpContext.Session.Id);
            return RedirectToAction("Index");
        }
        //if not already signed in, go to the login view
        [HttpGet]
        public IActionResult Login()
        {
            if (AuthenticationModel.GetSessionUser(HttpContext.Session.Id).Role.RoleName != "Anonymous")
                return RedirectToAction("Index");
            return View();
        }
        //if the user info is correct, go home, otherwise go to login get
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
        //get method displays register view if not already signed in
        [HttpGet]
        public IActionResult Register()
        {
            if (AuthenticationModel.GetSessionUser(HttpContext.Session.Id).Role.RoleName != "Anonymous")
                return RedirectToAction("Index");
            return View();
        }
        /*post method adds a new user using the authentication model if user doesnt already exist,
         * and logs in as that user
        */
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
