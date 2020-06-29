using System;
using Microsoft.AspNetCore.Mvc;
using ProjectCentral.Areas.AgeCalculator.Models;

namespace ProjectCentral.Areas.AgeCalculator.Controllers
{
    [Area("AgeCalculator")]
    public class AgeCalculatorHomeController : Controller
    {
        //get method of index returns the view
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //accepts personage model and calculates birthday, returns values to view
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
                    years, days, DateTime.Today.ToString("MM-dd-yyyy"));
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
