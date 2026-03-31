using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        static List<ContactInfo> contactInfo = new List<ContactInfo>()
        {
            new ContactInfo
            {
                ContactID=1,
                FirstName="Rohini",
                LastName = "Kumaras",
                CompanyName = "TechSoft",
                EmailId = "rohini@gmail.com",
                MobileNo = 9876543210,
                Designation = "Developer"
            },
            new ContactInfo
            {
                ContactID = 2,
                FirstName = "Suresh",
                LastName = "Reddyyy",
                CompanyName = "InfoTech",
                EmailId = "suresh@yahoo.com",
                MobileNo = 9123456780,
                Designation = "Manager"
            },
            new ContactInfo
            {
                ContactID = 3,
                FirstName = "Anitha",
                LastName = "Sharmas",
                CompanyName = "GlobalSys",
                EmailId = "anitha@gmail.com",
                MobileNo = 9012345678,
                Designation = "Analyst"
            },          
            new ContactInfo
            {
                ContactID = 4,
                FirstName = "Mahesh",
                LastName = "Prasadk",
                CompanyName = "NextGen",
                EmailId = "mahesh@outlook.com",
                MobileNo = 9988776655,
                Designation = "Tester"
            },          
            new ContactInfo
            {
                ContactID = 5,
                FirstName = "Kavitha",
                LastName = "Devians",
                CompanyName = "SoftWare",
                EmailId = "kavitha@gmail.com",
                MobileNo = 9090909090,
                Designation = "HR"
            }
        };

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowContacts()
        {
            return View(contactInfo);
        }

        [HttpGet]
        public IActionResult GetContactById(int id)
        {
            var contact = contactInfo.FirstOrDefault(info => info.ContactID == id);
            return View(contact);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contactinfo)
        {
            if (ModelState.IsValid)
            {
                contactInfo.Add(contactinfo);
                return RedirectToAction("ShowContacts");
            }

            return View(contactInfo);
        }
    }
}
