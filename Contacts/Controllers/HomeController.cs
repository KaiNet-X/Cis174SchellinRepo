using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DbWebAppSchellin.Models;

namespace DbWebAppSchellin.Controllers
{
    public class HomeController : Controller
    {
        ContactContext context;
        public HomeController(ContactContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Contact> contacts = context.Contacts.OrderBy(c => c.ID).ToList();
            return View(contacts);
        }
    }
}
