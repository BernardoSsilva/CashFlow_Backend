using Cashflow.Domain.entities;
using Cashflow.Domain.Repositories.expenses;

namespace Cashflow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesRepository
    {
        private readonly CashflowDbContext _DbContext;
        public ExpensesRepository(CashflowDbContext dbContext) 

        {
          
            _DbContext = dbContext;
        }
        public void add(Expense expense)
        {
            _DbContext.Expenses.Add(expense);
        }
    }
}
