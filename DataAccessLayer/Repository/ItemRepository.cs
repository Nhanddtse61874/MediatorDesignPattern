using DataAccessLayer.EntityModel;
using MediatorHandler.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DbContext _dbContext;
        DbSet<Item> _dbSet { get; set; }
        public ItemRepository(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<Item>();
        }

        public async Task AddAsync(Item entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Item> entities) => await _dbContext.AddRangeAsync(entities);

        public async Task ModifyAsync(Item entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result != null) _dbContext.Remove(result);
        }

        public IQueryable<Item> GetAll(Expression<Func<Item, bool>> filter = null, Func<IQueryable<Item>, IOrderedQueryable<Item>> orderBy = null, int? pageIndex = null, int? pageSize = null,
                                                                Func<IQueryable<Item>, IQueryable<Item>> includeProperties = null)
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
            return result;
        }

        public async Task<Item> GetByIdAsync(int id, Func<IQueryable<Item>, IQueryable<Item>> includeProperties)
        {
            var result = IncludeProperties(includeProperties);
            return await result.FirstOrDefaultAsync(x => x.Id == id);
        }

        private IQueryable<Item> IncludeProperties(Func<IQueryable<Item>, IQueryable<Item>> includeProperties = null)
        {
            return includeProperties == null ? _dbSet : includeProperties(_dbSet);
        }

        public IQueryable<Item> Get(Expression<Func<Item, bool>> filter, Func<IQueryable<Item>, IQueryable<Item>> includeProperties = null)
        {
            var result = IncludeProperties(includeProperties);

            return result.Where(filter);
        }

        public void DeleteRange(List<Item> entities)
        {
            if (entities.Any())
            {
                _dbContext.RemoveRange(entities);
            }
        }

        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<Item, TResult>> selector,
                                          Expression<Func<Item, bool>> predicate = null,
                                          Func<IQueryable<Item>, IOrderedQueryable<Item>> orderBy = null,
                                          Func<IQueryable<Item>, IQueryable<Item>> include = null,
                                          bool disableTracking = true)
        {
            IQueryable<Item> query = _dbSet;
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
