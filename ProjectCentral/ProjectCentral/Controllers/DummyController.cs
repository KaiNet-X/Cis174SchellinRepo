using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectCentral.Controllers
{
    public class DummyController : Controller
    {
        //goes to a blank page using the default route
        public IActionResult DefRoute()
        {
            return View();
        }
        //goes to a blank page using a custom route
        public IActionResult CustRoute()
        {
            return View();
        }
        //goes to a blank page using an atribute route
        [Route("DummyRoute/AttributeRoutingIsGreat/MoreGarbage/AttributeRouteeeeee/{id?}")]
        public IActionResult AttribRoute()
        {
            return View();
        }
    }
}
