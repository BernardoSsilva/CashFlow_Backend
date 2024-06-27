using Cashflow.Communication.Responses.expenses;

namespace Cashflow.Application.UseCases.Expenses.GetById.Interfaces
{
    public interface IGetExpenseByIdUseCase
    {
        Task<DetaildedExpenseResponse> Execute(long id);
    }
}
