using ProjectCentral.Areas.Contacts.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectCentral.Areas.Contacts.Controllers
{
    [Area("Contacts")]
    public class ContactsController : Controller
    {
        ContactContextModel context { get; }
        //constructor sets the context with dependencyinjection
        public ContactsController(ContactContextModel context)
        {
            this.context = context;
        }
        //add method redirects to edit view setting viewbag action to add passing an empty contactmodel
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return RedirectToAction("Edit", new ContactModel());
        }
        //get method sets action to dit and returns the edit view passing an existing contactmodel
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            ContactModel contact = context.Contacts.Find(ID);
            ViewBag.Action = "Edit";
            return View(contact);
        }
        //post method accepts contactmodel and if it is valid, upates or adds the model to the database
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
        //get method of delete returns delete view with contactmodel to delete
        [HttpGet]
        public IActionResult Delete(int ID)
        {
            ContactModel contact = context.Contacts.Find(ID);
            return View(contact);
        }
        //post method removes contact from database and redirect to home view
        [HttpPost]
        public IActionResult Delete(ContactModel contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "ContactsHome");
        }
        //returns view that shows details of contact
        public IActionResult Detail(int ID)
        {
            return View(context.Contacts.Find(ID));
        }
    }
}
