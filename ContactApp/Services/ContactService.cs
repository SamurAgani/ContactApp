using AutoMapper;
using ContactApp.Entities;
using ContactApp.RepositoryManager;
using ContactApp.ViewModels;

namespace ContactApp.Services
{
    public class ContactService : IContactService
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public ContactService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public void CreateContact(CreateContactVM Contact)
        {
            if (Contact.PhotoUrlFile != null)
            {
                string photoGuid = Guid.NewGuid().ToString();
                Contact.PhotoUrl = "/Photos/" + photoGuid + Contact.PhotoUrlFile.FileName;
                string photoUrl = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photos", photoGuid + Contact.PhotoUrlFile.FileName);
                using (var stream = new FileStream(photoUrl, FileMode.Create))
                {
                    Contact.PhotoUrlFile.CopyTo(stream);
                }
            }
            else
                Contact.PhotoUrl = "/Photos/default.png";

            _repositoryManager.Contacts.Add(_mapper.Map<Contact>(Contact));
            _repositoryManager.Save();
        }

        public void DeleteContact(Contact Contact)
        {
            _repositoryManager.Contacts.Delete(Contact);
            _repositoryManager.Save();
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

        public void UpdateContact(UpdateContactVM Contact)
        {
            if (Contact.PhotoUrlFile != null)
            {
                string photoGuid = Guid.NewGuid().ToString();
                Contact.PhotoUrl = "/Photos/" + photoGuid + Contact.PhotoUrlFile.FileName;
                string photoUrl = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photos", photoGuid + Contact.PhotoUrlFile.FileName);
                using (var stream = new FileStream(photoUrl, FileMode.Create))
                {
                    Contact.PhotoUrlFile.CopyTo(stream);
                }
            }
            else
                Contact.PhotoUrl = "/Photos/default.png";

            _repositoryManager.Contacts.Update(_mapper.Map<Contact>(Contact));
            _repositoryManager.Save();
        }

        public IEnumerable<Contact> GetByUserIdAndText(int UserId, string text)
        {
            var Contacts = _repositoryManager.Contacts.GetContactsByUserIdAndText(UserId, text);
            return Contacts;
        }
    }
}
