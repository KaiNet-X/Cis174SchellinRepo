using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectCentral.Controllers
{
    public class DummyController : Controller
    {
        public IActionResult DefRoute()
        {
            return View();
        }
        public IActionResult CustRoute()
        {
            return View();
        }
        [Route("DummyRoute/AttributeRoutingIsGreat/MoreGarbage/AttributeRouteeeeee/{id?}")]
        public IActionResult AttribRoute()
        {
            return View();
        }
    }
}
