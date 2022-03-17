using DataAccessLayer.EntityModel;
using System.Linq.Expressions;

namespace MediatorHandler.RepositoryInterface
{
    public interface IItemRepository
    {
        Task AddAsync(Item entity);

        Task AddRangeAsync(IEnumerable<Item> entities);

        Task ModifyAsync(Item entity);

        Task DeleteAsync(int id);

        IQueryable<Item> GetAll(
             Expression<Func<Item, bool>> filter = null,
             Func<IQueryable<Item>, IOrderedQueryable<Item>> orderBy = null,
             int? pageIndex = null, int? pageSize = null,
             Func<IQueryable<Item>, IQueryable<Item>> include = null
             );

        Task<Item> GetByIdAsync(int id, Func<IQueryable<Item>, IQueryable<Item>> includeProperties = null);

        IQueryable<Item> Get(Expression<Func<Item, bool>> filter, Func<IQueryable<Item>, IQueryable<Item>> includeProperties = null);

        void DeleteRange(List<Item> entities);

        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<Item, TResult>> selector,
                                          Expression<Func<Item, bool>> predicate = null,
                                          Func<IQueryable<Item>, IOrderedQueryable<Item>> orderBy = null,
                                          Func<IQueryable<Item>, IQueryable<Item>> include = null,
                                          bool disableTracking = true);
    }
}
