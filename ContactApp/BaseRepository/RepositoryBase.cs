using ContactApp.DBContext;
using System.Linq.Expressions;

namespace ContactApp.BaseRepository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private ContactDBContext _contactDBContext { get; set; }
        public RepositoryBase(ContactDBContext libraryDBContext)
        {
            _contactDBContext = libraryDBContext;
        }

        public void Add(T entity)
        {
            _contactDBContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _contactDBContext.Set<T>().Remove(entity);
        }
        //The AsNoTracking() extension method returns a new query and the returned entities will not be cached by the context (DbContext or _libraryDBContext)
        public IQueryable<T> GetAll()
        {
            return _contactDBContext.Set<T>();
        }

        public IQueryable<T> GetWithCondition(Expression<Func<T, bool>> expression)
        {
            return _contactDBContext.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
            _contactDBContext.Set<T>().Update(entity);
        }
    }
}
