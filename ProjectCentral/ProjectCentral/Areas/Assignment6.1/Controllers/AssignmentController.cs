using Microsoft.AspNetCore.Mvc;
using ProjectCentral.Areas.Assignment6._1.Models;

namespace ProjectCentral.Areas.Assignment6._1.Controllers
{
    [Route("{area}/{controller}/{action}/access-level-{accesslevel}")]
    public class AssignmentController : Controller
    {
        //returns studentview based on accesslevel
        public IActionResult StudentView(byte accesslevel)
        {
            StudentViewModel Students = new StudentViewModel(accesslevel);
            return View(Students);
        }
    }
}
