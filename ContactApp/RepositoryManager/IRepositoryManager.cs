using ContactApp.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace ContactApp.RepositoryManager
{
    public interface IRepositoryManager
    {
        void Save();
        IDbContextTransaction GetTransaction();
        UserRepository Users { get; }
        ContactRepository Contacts { get; }
    }
}
