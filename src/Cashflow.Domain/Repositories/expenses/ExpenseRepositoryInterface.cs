using Cashflow.Domain.entities;

namespace Cashflow.Domain.Repositories.expenses
{
    public interface IExpensesRepository
    {
        Task add(Expense expense);
        Task<List<Expense>> getAll();

        Task<Expense?> getById(long id);
    }
}
