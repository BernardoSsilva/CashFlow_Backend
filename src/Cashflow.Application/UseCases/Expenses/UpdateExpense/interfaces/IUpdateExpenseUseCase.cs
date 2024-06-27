using Cashflow.Communication.Requests.expenses;

namespace Cashflow.Application.UseCases.Expenses.UpdateExpense.interfaces
{
    public interface IUpdateExpenseUseCase
    {
        Task Execute(long id, RequestExpense requestBody);
    }
}
