using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjectCentral.Areas.Ticketing.Models;

namespace ProjectCentral.Areas.Ticketing.Controllers
{
    [Area("Ticketing")]
    public class TicketingHomeController : Controller
    {
        private TicketContext Context;
        //initialize context
        public TicketingHomeController (TicketContext context)
        {
            Context = context;
        }
        //default empty filters, returns index view with filtering
        [HttpGet]
        public IActionResult Index(Filters filter = null)
        {
            List<Ticket> Tickets = new List<Ticket>();
            if (Context.Tickets.Count() > 0)
            {
                if (filter != null)
                {
                    Tickets = Context.Tickets.Where(T => T.PointValue >= filter.PointFilter)
                        .Where(T => T.Status >= filter.StatFilter).ToList();
                }
                else
                {
                    Tickets = Context.Tickets.ToList();
                }
            }
            HomeViewModel Model = new HomeViewModel { Tickets = Tickets, Filter = filter };
            return View(Model);
        }
        //binds homeviewmodel and uses its update ticket to either delete or increment the status
        [HttpPost]
        public IActionResult Index(HomeViewModel ticket)
        {
            if(ticket.UpdateTicket.PointValue == 0)
            {
                Context.Tickets.Remove(Context.Tickets.Find(ticket.UpdateTicket.SprintNumber));
            }
            else
            {
                Ticket full = Context.Tickets.Find(ticket.UpdateTicket.SprintNumber);
                full.Status = ticket.UpdateTicket.Status;
                Context.Tickets.Update(full);
            }
            
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
