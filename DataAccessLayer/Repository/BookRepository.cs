using DataAccessLayer.EntityModel;
using DataAccessLayer.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly BookStoreDbContext _dbContext;
        DbSet<Book> _dbSet { get; set; }
        public BookRepository(BookStoreDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<Book>();
        }

        public async Task AddAsync(Book entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Book> entities) => await _dbContext.AddRangeAsync(entities);

        public async Task ModifyAsync(Book entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result != null) _dbContext.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Book> GetAll(Expression<Func<Book, bool>> filter = null, Func<IQueryable<Book>, IOrderedQueryable<Book>> orderBy = null, int? pageIndex = null, int? pageSize = null,
                                                                Func<IQueryable<Book>, IQueryable<Book>> includeProperties = null)
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

        public async Task<Book> GetByIdAsync(int id, Func<IQueryable<Book>, IQueryable<Book>> includeProperties)
        {
            var result = IncludeProperties(includeProperties);
            return await result.FirstOrDefaultAsync(x => x.Id == id);
        }

        private IQueryable<Book> IncludeProperties(Func<IQueryable<Book>, IQueryable<Book>> includeProperties = null)
        {
            return includeProperties == null ? _dbSet : includeProperties(_dbSet);
        }

        public IQueryable<Book> Get(Expression<Func<Book, bool>> filter, Func<IQueryable<Book>, IQueryable<Book>> includeProperties = null)
        {
            var result = IncludeProperties(includeProperties);

            return result.Where(filter);
        }

        public void DeleteRange(List<Book> entities)
        {
            if (entities.Any())
            {
                _dbContext.RemoveRange(entities);
            }
             _dbContext.SaveChanges();
        }

        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<Book, TResult>> selector,
                                          Expression<Func<Book, bool>> predicate = null,
                                          Func<IQueryable<Book>, IOrderedQueryable<Book>> orderBy = null,
                                          Func<IQueryable<Book>, IQueryable<Book>> include = null,
                                          bool disableTracking = true)
        {
            IQueryable<Book> query = _dbSet;
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
