using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCentral.Areas.Ticketing.Models
{
    public class HomeViewModel
    {
        public List<Ticket> Tickets { get; set; }
        public Ticket UpdateTicket { get; set; }
        public Filters Filter { get; set; }
    }
}
