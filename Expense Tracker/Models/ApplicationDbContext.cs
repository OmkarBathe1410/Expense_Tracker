using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Models
{
    public class ApplicationDbContext:DbContext // Inherit from EntityCore Framework <= (DbContext)
    {
        public ApplicationDbContext(DbContextOptions options):base(options) {
            
        }

        public DbSet<Transaction> Transactions { get; set; } // Table Name = Transactions
        public DbSet<Category> Categories { get; set; } // Table Name = Categories
    }
}
