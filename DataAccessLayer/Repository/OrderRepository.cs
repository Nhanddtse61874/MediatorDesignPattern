using DataAccessLayer.EntityModel;
using DataAccessLayer.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContext _dbContext;
        DbSet<Order> _dbSet { get; set; }
        public OrderRepository(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<Order>();
        }

        public async Task AddAsync(Order entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Order> entities) => await _dbContext.AddRangeAsync(entities);

        public async Task ModifyAsync(Order entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result != null) _dbContext.Remove(result);
        }

        public IQueryable<Order> GetAll(Expression<Func<Order, bool>> filter = null, Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null, int? pageIndex = null, int? pageSize = null, Func<IQueryable<Order>, IQueryable<Order>> includeProperties = null)
        {
            var result = IncludeProperties(includeProperties);
            if (filter != null)
            {
                result = result.Where(filter);
            }
            if (orderBy != null)
            {
                result = orderBy(result);
            }
            if (pageIndex != null && pageSize != null)
            {
                result = result.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return result.Include(x => x.Items);
        }

        public async Task<Order> GetByIdAsync(int id, Func<IQueryable<Order>, IQueryable<Order>> includeProperties)
        {
            var result = IncludeProperties(includeProperties);
            return await result.FirstOrDefaultAsync(x => x.Id == id);
        }

        private IQueryable<Order> IncludeProperties(Func<IQueryable<Order>, IQueryable<Order>> includeProperties = null)
        {
            return includeProperties == null ? _dbSet : includeProperties(_dbSet);
        }

        public IQueryable<Order> Get(Expression<Func<Order, bool>> filter, Func<IQueryable<Order>, IQueryable<Order>> includeProperties = null)
        {
            var result = IncludeProperties(includeProperties);

            return result.Where(filter);
        }

        public void DeleteRange(List<Order> entities)
        {
            if (entities.Any())
            {
                _dbContext.RemoveRange(entities);
            }
        }

        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<Order, TResult>> selector,
                                          Expression<Func<Order, bool>> predicate = null,
                                          Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null,
                                          Func<IQueryable<Order>, IQueryable<Order>> include = null,
                                          bool disableTracking = true)
        {
            IQueryable<Order> query = _dbSet;
            if (disableTracking)
            {
                query = _dbSet.AsNoTracking();
            }

            if (include != null)
            {
                query = include(_dbSet);
            }

            if (predicate != null)
            {
                query = _dbSet.Where(predicate);
            }

            if (orderBy != null)
            {
                return await orderBy(_dbSet).Select(selector).FirstOrDefaultAsync();
            }
            else
            {
                return await _dbSet.Select(selector).FirstOrDefaultAsync();
            }
        }
    }
}
