using Microsoft.EntityFrameworkCore;

namespace ProjectCentral.Areas.Contacts.Models
{
    public class ContactContextModel : DbContext
    {
        public ContactContextModel(DbContextOptions<ContactContextModel> options)
            : base(options) { }

        public DbSet<ContactModel> Contacts { get; set; }
    }
}
