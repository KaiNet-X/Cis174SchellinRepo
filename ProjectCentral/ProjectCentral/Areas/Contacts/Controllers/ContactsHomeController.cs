using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjectCentral.Areas.Contacts.Models;

namespace ProjectCentral.Areas.Contacts.Controllers
{
    [Area("Contacts")]
    public class ContactsHomeController : Controller
    {
        ContactContextModel context;
        //sets context with dependency injection
        public ContactsHomeController(ContactContextModel context)
        {
            this.context = context;
        }
        //returns index fiew that lists all contacts
        public IActionResult Index()
        {
            List<ContactModel> contacts = context.Contacts.OrderBy(c => c.ID).ToList();
            return View(contacts);
        }
    }
}
