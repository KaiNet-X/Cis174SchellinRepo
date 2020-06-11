using ProjectCentral.Areas.FutureValue.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectCentral.Areas.FutureValue.Controllers
{
    [Area("FutureValue")]
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
