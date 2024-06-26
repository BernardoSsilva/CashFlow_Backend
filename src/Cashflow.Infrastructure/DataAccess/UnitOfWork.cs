using Cashflow.Domain.Repositories;

namespace Cashflow.Infrastructure.DataAccess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly CashflowDbContext _DbContext;

        public UnitOfWork(CashflowDbContext dbContext)

        {

            _DbContext = dbContext;
        }
        public async Task Commit() => await _DbContext.SaveChangesAsync();
    }
}
