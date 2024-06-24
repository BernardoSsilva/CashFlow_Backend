using Cashflow.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace Cashflow.Infrastructure.DataAccess
{
    public class CashflowDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost:5432;Database=cashflow_db;Uid=root;pwd=@password123";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 37));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}