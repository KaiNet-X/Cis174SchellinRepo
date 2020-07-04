using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCentral.Areas.Ticketing.Models;

namespace ProjectCentral.Areas.Ticketing.Controllers
{
    [Area("Ticketing")]
    public class TicketingController : Controller
    {
        private TicketContext Context;
        //initialize context
        public TicketingController(TicketContext context)
        {
            Context = context;
        }
        //pass empty ticket to add view
        [HttpGet]
        public IActionResult Add()
        {
            Ticket ticket = new Ticket();
            return View(ticket);
        }
        //add the ticket to the tickets database
        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                Context.Tickets.Add(ticket);
                Context.SaveChanges();
                return RedirectToAction("Index", "TicketingHome");
            }
            return View(ticket);
        }
    }
}
