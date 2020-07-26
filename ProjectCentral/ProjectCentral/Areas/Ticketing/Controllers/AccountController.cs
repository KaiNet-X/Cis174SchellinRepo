using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectCentral.Areas.Ticketing.Models;
using ProjectCentral.Areas.Ticketing.Models.ViewModels;

namespace ProjectCentral.Areas.Ticketing.Controllers
{
    [Area("Ticketing")]
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private SignInManager<User> signInManager;
        public AccountController(UserManager<User> uMan, RoleManager<IdentityRole> rMan, SignInManager<User> siMan)
        {
            userManager = uMan;
            roleManager = rMan;
            signInManager = siMan;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                User u = new User { UserName = user.Username };

                IdentityResult res = await userManager.CreateAsync(u, user.Password);
                if (res.Succeeded)
                {
                    await signInManager.PasswordSignInAsync(u, user.Password, false, false);
                    return RedirectToAction("Index", "TicketingHome");
                }
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel user)
        {
            if (ModelState.IsValid)
            {
                var res = await signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);
                if (res.Succeeded)
                    return RedirectToAction("Index", "TicketingHome");
            }
            ModelState.AddModelError("", "Invalid Username or passowrd");
            return View(user);
        }
        [Authorize]
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "TicketingHome");
        }
    }
}
