using DataAccessLayer.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
