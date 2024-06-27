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


        // find expense by id
        public async Task<Expense?> getById(long id)
        {
            return await _DbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(expense => expense.Id == id);
        }


        // find all expenses

        async Task<List<Expense>> IExpensesRepository.getAll()
        {
            return await _DbContext.Expenses.AsNoTracking().ToListAsync();
        }


        // delete expense
        public async Task<bool> deletExpense(long id)
        {
           
            var result = await _DbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);

            if(result is null)
            {
                return false;
            }

            _DbContext.Expenses.Remove(result);
            return true;
                
        }

        //update expense

        public void update(Expense expenseNewData)
        {   
            _DbContext.Expenses.Update(expenseNewData);
        }

        public async Task<Expense> getByIdToUpdate(long id)
        {
            var result = await _DbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);
            return result;
        }
    }
}
