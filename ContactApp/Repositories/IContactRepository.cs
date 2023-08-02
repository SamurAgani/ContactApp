using ContactApp.Entities;

namespace ContactApp.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetById(int id);
        void CreateContact(Contact Contact);
        void UpdateContact(Contact Contact);
        void DeleteContact(Contact Contact);
        IEnumerable<Contact> GetContactsByUserIdAndText(int userId, string text);
    }
}
