namespace Cashflow.Application.UseCases.Expenses.DeleteExpense.interfaces
{
    public interface IDeleteExpenseUseCase
    {
        Task Execute(long id);
    }
}
