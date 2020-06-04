using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DbWebAppSchellin.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<Contact>().HasData(
        //        new Contact { ID = 1, Name = "Sally", PhoneNumber = "(515)-656-8969" },
        //        new Contact { ID = 2, Name = "Bob", PhoneNumber = "1-800-585-3920" });
        //}
    }
}
