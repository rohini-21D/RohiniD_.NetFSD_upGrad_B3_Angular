using ContactWebAPI.DataAccess;
using ContactWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repo;
        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        //GetAllContacts

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            return Ok(_repo.GetContacts());
        }

        //GetById
        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id");

            var contact = _repo.GetById(id);

            if (contact == null)
                return BadRequest("Not Found");

            return Ok(contact);
        }

        //Create
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var created = _repo.Add(contact);
                return Ok(new { contact, status = "New Contact Successfully addes.." });
            }
        }

        //update
        [HttpPut("{id}")]
        public IActionResult EditContact(int id,Contact contact)
        {
            
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
        
            var update = _repo.Update(id, contact);

            return Ok(new { UpdateContact = update, status = "Contact got Updated" });
          
        }
        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            var delete=_repo.Delete(id);

            return Ok(delete);
        }
    }
}
