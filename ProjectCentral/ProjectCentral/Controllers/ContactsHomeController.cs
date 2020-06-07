﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectCentral.Models;

namespace ProjectCentral.Controllers
{
    public class ContactsHomeController : Controller
    {
        ContactContextModel context;
        public ContactsHomeController(ContactContextModel context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<ContactModel> contacts = context.Contacts.OrderBy(c => c.ID).ToList();
            return View(contacts);
        }
    }
}
