using Microsoft.EntityFrameworkCore;

namespace ProjectCentral.Areas.Contacts.Models
{
    public class ContactContextModel : DbContext
    {
        //constructor passes options to base
        public ContactContextModel(DbContextOptions<ContactContextModel> options)
            : base(options) { }
        //adds contact entity to database
        public DbSet<ContactModel> Contacts { get; set; }
    }
}
