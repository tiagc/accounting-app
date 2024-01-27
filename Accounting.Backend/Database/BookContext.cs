using BookApp.Backend.Database;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Backend.Database
{
    public class BookContext : DbContext
    {
        public DbSet<BookContext> Customers { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookContext() { }

        public BookContext(DbContextOptions<BookContext> options) : base(options) { }
    }
}
