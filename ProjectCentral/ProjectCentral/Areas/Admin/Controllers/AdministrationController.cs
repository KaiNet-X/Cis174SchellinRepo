using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectCentral.Models;

namespace ProjectCentral.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdministrationController : Controller
    {
        //dependency injection, sets usercontext
        public AdministrationController(UserContextModel context)
        {
            AuthenticationModel.UserContext = context;
        }
        //if signed in user is admin, go to adminpage view, otherwise redirect home
        public IActionResult AdminPage()
        {
            if (AuthenticationModel.GetSessionUser(HttpContext.Session.Id).Role.RoleName != "Administrator")
                return RedirectToAction("Index", "Home", new { area = "" });
            return View(AuthenticationModel.GetBasicUsers());
        }
        //get method of delete displays the delete view if the user is an administrator
        [HttpGet]
        public IActionResult Delete(int ID)
        {
            if (AuthenticationModel.GetSessionUser(HttpContext.Session.Id).Role.RoleName != "Administrator")
                return RedirectToAction("Index", "Home", new { area = "" });
            return View(AuthenticationModel.GetUserWithID(ID));
        }
        //deletes the user from the database and goes back to the adminpage
        [HttpPost]
        public IActionResult Delete(UserModel User)
        {
            AuthenticationModel.RemoveUser(User);
            return RedirectToAction("Adminpage");
        }
    }
}
