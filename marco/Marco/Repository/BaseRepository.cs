using System.Linq.Expressions;

namespace Marco.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly MainContext _mainContext;
        public BaseRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }
        public IEnumerable<T> GetByReplicaContext<T>(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>,
            IOrderedQueryable<T>>? orderBy = null, string includeProperties = "", bool isNoTracking = true) where T : class
        {
            IQueryable<T> query = _mainContext.GetReplicaContext.Set<T>();
            return QueryExecute(query, filter, orderBy, includeProperties, isNoTracking);
        }
        public IEnumerable<T> QueryExecute<T>(IQueryable<T> query, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>
           , IOrderedQueryable<T>>? orderBy = null, string includeProperties = "", bool isNoTracking = true) where T : class
        {
            if (isNoTracking)
                query.AsNoTracking();
            if (filter != null)
                query = query.Where(filter);
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return (orderBy != null) ? orderBy(query).ToList() : query.ToList();
        }
    }
}
