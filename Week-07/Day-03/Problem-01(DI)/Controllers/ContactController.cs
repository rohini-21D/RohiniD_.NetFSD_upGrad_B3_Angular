using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        //all contactts
        public IActionResult ShowAllContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        //Get by id
        public IActionResult GetContactById(int id)
        {
            var contact=_contactService.GetContactById(id);
            return View(contact);
        }

        //get Add
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.AddContact(contact);
                return RedirectToAction("ShowAllContacts");
            }
            return View(contact);
        }
    }
}
