using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ProjectCentral.Models
{
    public class ContactContextModel : DbContext
    {
        public ContactContextModel(DbContextOptions<ContactContextModel> options)
            : base(options) { }

        public DbSet<ContactModel> Contacts { get; set; }
    }
}
