using ContactApp.BaseRepository;
using ContactApp.DBContext;
using ContactApp.Entities;

namespace ContactApp.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private IConfiguration _configuration { get; set; }
        public UserRepository(ContactDBContext dBContext, IConfiguration Configuration) : base(dBContext)
        {
            _configuration = Configuration;
        }
        public void CreateUser(User User)
        {
            Add(User);
        }

        public void DeleteUser(User User)
        {
            Delete(User);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return GetAll();
        }

        public User GetById(int id)
        {
            return GetWithCondition(c => c.Id == id).FirstOrDefault();
        }

        public void UpdateUser(User User)
        {
            Update(User);
        }
    }
}
