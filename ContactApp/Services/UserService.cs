using ContactApp.Entities;
using ContactApp.RepositoryManager;
using ContactApp.ViewModels;

namespace ContactApp.Services
{
    public class UserService : IUserService
    {
        private IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public User CheckUser(LoginVM vMLogin)
        {
            var user = _repositoryManager.Users.GetWithCondition(x => x.Email == vMLogin.Email && x.Password == vMLogin.Password).FirstOrDefault();
            return user;
        }

        public void CreateUser(User user)
        {
            _repositoryManager.Users.Add(user);
            _repositoryManager.Save();
        }

        public void DeleteUser(User user)
        {
            _repositoryManager.Users.Delete(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repositoryManager.Users.GetAllUsers();
        }

        public User GetByEmail(string mail)
        {
            var user = _repositoryManager.Users.GetWithCondition(x => x.Email == mail).FirstOrDefault();
            return user;
        }

        public User GetById(int id)
        {
            return _repositoryManager.Users.GetById(id);
        }

        public void UpdateUser(User user)
        {
            _repositoryManager.Users.Update(user);
            _repositoryManager.Save();
        }
    }
}
