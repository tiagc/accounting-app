using BookApp.Backend.Database;
using Microsoft.EntityFrameworkCore;

namespace Book.Backend.Database
{
    public class AuthorContext : DbContext
    {
        public DbSet<AuthorContext> Authors { get; set; }

        public AuthorContext() { }

        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options) { }
    }
}
