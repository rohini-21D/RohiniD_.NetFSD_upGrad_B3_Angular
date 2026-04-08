using ContactWebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ContactWebAPI.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        public static List<Contact> contacts = new List<Contact>()
        {
            new Contact{ContactId=1,FirstName="D",LastName="Rohini",EmailId="abc@gmail.com",MobileNo=9876543210,Designation="Dev"},
            new Contact{ContactId=2,FirstName="Pavan",LastName="Kumar",EmailId="def@gmail.com",MobileNo=9876543211,Designation="Mng"}
        };

        public IEnumerable<Contact> GetContacts()
        {
            return contacts;
        }

        public Contact GetById(int id)
        {
            return contacts.FirstOrDefault(i => i.ContactId == id);
            
        }

        public Contact Add(Contact contact)
        {
            contact.ContactId = contacts.Max(i => i.ContactId) + 1;
            contacts.Add(contact);
            return contact;
        }

        public Contact Update(int id, Contact contact)
        {
            var existing=contacts.Find(i => i.ContactId == id);
            if (existing == null)
            {
                return null;
            }
            else
            {
                existing.FirstName= contact.FirstName;
                existing.LastName= contact.LastName;
                existing.EmailId= contact.EmailId;
                existing.MobileNo= contact.MobileNo;
                existing.Designation= contact.Designation;
                
                return existing;
            }
        }

        public Contact Delete(int id)
        {
            var exId = contacts.Find(i => i.ContactId == id);
            if (exId == null)
            {
                return null;
            }
            else
            {
                contacts.Remove(exId);
                return (exId);
            }
        }
    }
}
