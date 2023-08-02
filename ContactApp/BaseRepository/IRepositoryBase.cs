using System.Linq.Expressions;

namespace ContactApp.BaseRepository
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWithCondition(Expression<Func<T, bool>> expression);

        void Add(T entity);
        void Update(T entity);

        void Delete(T entity);
    }
}
