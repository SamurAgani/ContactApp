using ContactApp.Entities;
using ContactApp.RepositoryManager;

namespace ContactApp.Services
{
    public class ContactService : IContactService
    {
        private IRepositoryManager _repositoryManager;

        public ContactService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public void CreateContact(Contact Contact)
        {
            _repositoryManager.Contacts.Add(Contact);
            _repositoryManager.Save();
        }

        public void DeleteContact(Contact Contact)
        {
            _repositoryManager.Contacts.Delete(Contact);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _repositoryManager.Contacts.GetAllContacts();
        }

        public IEnumerable<Contact> GetByUserId(int userId)
        {
            var Contacts = _repositoryManager.Contacts.GetWithCondition(x => x.UserId == userId);
            return Contacts;
        }

        public Contact GetById(int id)
        {
            return _repositoryManager.Contacts.GetById(id);
        }

        public void UpdateContact(Contact Contact)
        {
            _repositoryManager.Contacts.Update(Contact);
        }
    }
}
