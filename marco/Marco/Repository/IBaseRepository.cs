using System.Linq.Expressions;

namespace Marco.Repository
{
    public interface IBaseRepository
    {
        IEnumerable<T> GetByReplicaContext<T>(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null
           , string includeProperties = "", bool isNoTracking = true) where T : class;
    }
}
