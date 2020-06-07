using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectCentral.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectCentral.Controllers
{
    public class FutureValueHomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FV = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Index(FutureValueModel model)
        {
            if (ModelState.IsValid) ViewBag.FV = model.CalculatefutureValue();
            else ViewBag.FV = 0;
            return View(model);
        }
    }
}
