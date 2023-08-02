using ContactApp.Entities;

namespace ContactApp.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetById(int id);
        IEnumerable<Contact> GetByUserId(int UserId);
        void CreateContact(Contact Contact);
        void UpdateContact(Contact Contact);
        void DeleteContact(Contact Contact);
    }
}
