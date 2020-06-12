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
        public AdministrationController(UserContextModel context)
        {
            AuthenticationModel.UserContext = context;
        }
        public IActionResult AdminPage()
        {
            if (AuthenticationModel.GetSessionUser(HttpContext.Session.Id).Role.RoleName != "Administrator")
                return RedirectToAction("Index", "Home", new { area = "" });
            return View(AuthenticationModel.GetBasicUsers());
        }
        [HttpGet]
        public IActionResult Delete(int ID)
        {
            if (AuthenticationModel.GetSessionUser(HttpContext.Session.Id).Role.RoleName != "Administrator")
                return RedirectToAction("Index", "Home", new { area = "" });
            return View(AuthenticationModel.GetUserWithID(ID));
        }
        [HttpPost]
        public IActionResult Delete(UserModel User)
        {
            AuthenticationModel.RemoveUser(User);
            return RedirectToAction("Adminpage");
        }
    }
}
