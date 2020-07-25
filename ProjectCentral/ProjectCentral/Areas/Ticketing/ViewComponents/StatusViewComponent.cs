using Microsoft.AspNetCore.Mvc;
using ProjectCentral.Areas.Ticketing.Models;

namespace ProjectCentral.Areas.Ticketing.ViewComponents
{
    public class StatusViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Ticket ticket)
        {
            return View(ticket);
        }
    }
}