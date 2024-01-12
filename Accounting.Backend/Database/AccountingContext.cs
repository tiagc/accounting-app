using Microsoft.EntityFrameworkCore;

namespace Accounting.Backend.Database
{
    public class AccountingContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bill> Bills { get; set; }

        public AccountingContext() { }

        public AccountingContext(DbContextOptions<AccountingContext> options) : base(options) { }
    }
}
