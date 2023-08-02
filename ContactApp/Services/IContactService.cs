using ContactApp.Entities;
using ContactApp.ViewModels;

namespace ContactApp.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetById(int id);
        IEnumerable<Contact> GetByUserId(int UserId);
        IEnumerable<Contact> GetByUserIdAndText(int UserId, string text);
        void CreateContact(CreateContactVM Contact);
        void UpdateContact(UpdateContactVM Contact);
        void DeleteContact(Contact Contact);
    }
}
