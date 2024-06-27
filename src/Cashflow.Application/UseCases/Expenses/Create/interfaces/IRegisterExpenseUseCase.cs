using Cashflow.Communication.Requests.expenses;
using Cashflow.Communication.Responses.expenses;

namespace Cashflow.Application.UseCases.Expenses.Create.interfaces
{
    public interface IRegisterExpenseUseCase
    {
        Task<ExpenseResponse> Execute(RequestExpense requestBody);
    }
}
