using ContactApp.BaseRepository;
using ContactApp.DBContext;
using ContactApp.Entities;

namespace ContactApp.Repositories
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        private IConfiguration _configuration { get; set; }
        public ContactRepository(ContactDBContext dBContext, IConfiguration Configuration) : base(dBContext)
        {
            _configuration = Configuration;
        }
        public void CreateContact(Contact Contact)
        {
            Add(Contact);
        }

        public void DeleteContact(Contact Contact)
        {
            Delete(Contact);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return GetAll();
        }

        public Contact GetById(int id)
        {
            return GetWithCondition(c => c.Id == id).FirstOrDefault();
        }

        public void UpdateContact(Contact Contact)
        {
            Update(Contact);
        }
    }
}
