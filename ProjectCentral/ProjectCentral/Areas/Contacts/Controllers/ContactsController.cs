using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectCentral.Areas.Contacts.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectCentral.Areas.Contacts.Controllers
{
    [Area("Contacts")]
    public class ContactsController : Controller
    {
        ContactContextModel context { get; }
        public ContactsController(ContactContextModel context)
        {
            this.context = context;
        }
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return RedirectToAction("Edit", new ContactModel());
        }
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            ContactModel contact = context.Contacts.Find(ID);
            ViewBag.Action = "Edit";
            return View(contact);
        }
        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ID != 0) context.Contacts.Update(contact);
                else context.Contacts.Add(contact);
                context.SaveChanges();
                return RedirectToAction("Index", "ContactsHome");
            }
            else
            {
                if (contact.ID == 0) ViewBag.Action = "Add";
                else ViewBag.Action = "Edit";
                return View(contact);
            }
        }
        [HttpGet]
        public IActionResult Delete(int ID)
        {
            ContactModel contact = context.Contacts.Find(ID);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Delete(ContactModel contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "ContactsHome");
        }
        public IActionResult Detail(int ID)
        {
            return View(context.Contacts.Find(ID));
        }
    }
}
