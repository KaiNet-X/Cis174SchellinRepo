using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectCentral.Areas.Assignment6._1.Models;

namespace ProjectCentral.Areas.Assignment6._1.Controllers
{
    [Route("{area}/{controller}/{action}/access-level-{accesslevel}")]
    public class AssignmentController : Controller
    {
        public IActionResult StudentView(byte accesslevel)
        {
            StudentViewModel Students = new StudentViewModel(accesslevel);
            //Students.Students.Add(new StudentModel { FirstName = "Billy", LastName = "Bob", Grade = 'C'});
            return View(Students);
        }
    }
}
