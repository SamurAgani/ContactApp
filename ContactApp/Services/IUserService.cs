using ContactApp.Entities;
using ContactApp.ViewModels;

namespace ContactApp.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetById(int id);
        User GetByEmail(string mail);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        User CheckUser(LoginVM loginVM);
    }
}
