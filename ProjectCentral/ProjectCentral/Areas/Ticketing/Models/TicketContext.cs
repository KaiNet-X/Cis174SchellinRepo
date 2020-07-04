using Microsoft.EntityFrameworkCore;

namespace ProjectCentral.Areas.Ticketing.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options)
            :base(options) { }

        public DbSet<Ticket> Tickets { get; set; }

    }
}
