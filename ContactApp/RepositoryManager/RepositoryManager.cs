using ContactApp.DBContext;
using ContactApp.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace ContactApp.RepositoryManager
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ContactDBContext _dbContext;
        private readonly IConfiguration _configuration;

        public RepositoryManager(ContactDBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        private UserRepository _userRepository;
        public UserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_dbContext, _configuration);
                return _userRepository;
            }
        }

        private ContactRepository _contactRepository;
        public ContactRepository Contacts
        {
            get
            {
                if (_contactRepository == null)
                    _contactRepository = new ContactRepository(_dbContext, _configuration);
                return _contactRepository;
            }
        }

        public IDbContextTransaction GetTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
