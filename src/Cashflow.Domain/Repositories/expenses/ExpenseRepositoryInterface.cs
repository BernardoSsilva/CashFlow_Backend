using Cashflow.Domain.entities;

namespace Cashflow.Domain.Repositories.expenses
{
    public interface IExpensesRepository
    {
        Task add(Expense expense);
        Task<List<Expense>> getAll();

        Task<Expense?> getById(long id);

        Task<bool> deletExpense(long id);

        void update(Expense expenseNewData);

        Task<Expense> getByIdToUpdate(long id);
    }
}
