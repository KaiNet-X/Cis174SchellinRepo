using ProjectCentral.Areas.FutureValue.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectCentral.Areas.FutureValue.Controllers
{
    [Area("FutureValue")]
    public class FutureValueHomeController : Controller
    {
        //get method displays index view with 0 futurevalue
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FV = 0;
            return View();
        }
        //post method calculates futurevalue and returns model to view
        [HttpPost]
        public IActionResult Index(FutureValueModel model)
        {
            if (ModelState.IsValid) ViewBag.FV = model.CalculatefutureValue();
            else ViewBag.FV = 0;
            return View(model);
        }
    }
}
