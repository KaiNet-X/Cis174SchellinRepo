using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstResponsiveWebAppSchellin.Models;

namespace FirstResponsiveWebAppSchellin.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(PersonAgeModel personAgeModel)
        {
            if (ModelState.IsValid)
            {
                personAgeModel.Name = personAgeModel.Name.ToUpper();
                if (personAgeModel.Birthday != null)
                {
                    TimeSpan ageToday = personAgeModel.AgeToday().Value;
                    int years = (ageToday.Days / 365);
                    int days = ageToday.Days - (years * 365);
                    ViewBag.Result = personAgeModel.Name + " is " +
                    string.Format("{0} years and {1} days as of {2}",
                    years, days, DateTime.Now.ToString());
                }
                else
                {
                    ViewBag.Result = personAgeModel.Name + " is " + personAgeModel.AgeThisYear().ToString();
                }
            }
            else ViewBag.Result = "";

            return View(personAgeModel);
            
        }
    }
}
