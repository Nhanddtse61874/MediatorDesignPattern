using DataAccessLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoryInterface
{
    public interface IBookRepository 
    {
            Task AddAsync(Book entity);

            Task AddRangeAsync(IEnumerable<Book> entities);

            Task ModifyAsync(Book entity);

            Task DeleteAsync(int id);

            IQueryable<Book> GetAll(
                 Expression<Func<Book, bool>> filter = null,
                 Func<IQueryable<Book>, IOrderedQueryable<Book>> orderBy = null,
                 int? pageIndex = null, int? pageSize = null,
                 Func<IQueryable<Book>, IQueryable<Book>> include = null
                 );

            Task<Book> GetByIdAsync(int id, Func<IQueryable<Book>, IQueryable<Book>> includeProperties = null);

            IQueryable<Book> Get(Expression<Func<Book, bool>> filter, Func<IQueryable<Book>, IQueryable<Book>> includeProperties = null);

            void DeleteRange(List<Book> entities);

            Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<Book, TResult>> selector,
                                              Expression<Func<Book, bool>> predicate = null,
                                              Func<IQueryable<Book>, IOrderedQueryable<Book>> orderBy = null,
                                              Func<IQueryable<Book>, IQueryable<Book>> include = null,
                                              bool disableTracking = true);
    }
}
