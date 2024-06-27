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
        // add new expense
        async Task IExpensesRepository.add(Expense expense)
        {
            await _DbContext.Expenses.AddAsync(expense);
        }


        public async Task<Expense?> getById(long id)
        {
            return await _DbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(expense => expense.Id == id);
        }


       
        async Task<List<Expense>> IExpensesRepository.getAll()
        {
            return await _DbContext.Expenses.AsNoTracking().ToListAsync();
        }

    }
}
