using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectCentral.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdministrationController : Controller
    {
        public IActionResult AdminPage()
        {
            return View();
        }
    }
}
