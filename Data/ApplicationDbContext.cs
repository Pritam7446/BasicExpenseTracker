using BasicExpenseTracker.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BasicExpenseTracker.Models;

namespace BasicExpenseTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // This creates an 'Expenses' table in your SQL database
        public DbSet<Expense> Expenses { get; set; }
    }
}
