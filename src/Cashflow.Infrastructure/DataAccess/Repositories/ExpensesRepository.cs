using Cashflow.Domain.entities;
using Cashflow.Domain.Repositories.expenses;
using Microsoft.EntityFrameworkCore;

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

        async Task IExpensesRepository.add(Expense expense)
        {
            await _DbContext.Expenses.AddAsync(expense);
        }

        async Task<List<Expense>> IExpensesRepository.getAll()
        {
            return await _DbContext.Expenses.ToListAsync();
        }

    }
}
