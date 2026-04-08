using ContactWebAPI.Models;

namespace ContactWebAPI.DataAccess
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContacts();
        Contact GetById(int id);
        Contact Add(Contact contact);
        Contact Update(int id, Contact contact);
        Contact Delete(int id);
    }
}
