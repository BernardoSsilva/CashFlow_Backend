using Cashflow.Communication.Responses.expenses;

namespace Cashflow.Application.UseCases.Expenses.GetAll.Interfaces
{
    public interface IGetAllExpensesUseCase
    {

        Task<MultipleExpensesResponse> Execute();
    }
}
