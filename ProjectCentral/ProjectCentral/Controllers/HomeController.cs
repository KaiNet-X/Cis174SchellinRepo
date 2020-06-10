using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using ProjectCentral.Models;
using Microsoft.AspNetCore.Session;

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
            return View();
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
                AuthenticationModel.AddSessionUser(User, HttpContext.Session.Id);
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
                AuthenticationModel.AddSessionUser(User, HttpContext.Session.Id);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
