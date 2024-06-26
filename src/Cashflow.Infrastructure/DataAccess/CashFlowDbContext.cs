using Cashflow.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace Cashflow.Infrastructure.DataAccess
{
    internal class CashflowDbContext : DbContext
    {
        public CashflowDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Expense> Expenses { get; set; }

       
    }
}