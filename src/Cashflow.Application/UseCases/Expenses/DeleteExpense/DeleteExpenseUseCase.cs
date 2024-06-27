using Cashflow.Application.UseCases.Expenses.DeleteExpense.interfaces;
using Cashflow.Domain.Repositories;
using Cashflow.Domain.Repositories.expenses;
using Cashflow.Exception;
using Cashflow.Exception.exceptions;

namespace Cashflow.Application.UseCases.Expenses.DeleteExpense
{
    internal class DeleteExpenseUseCase : IDeleteExpenseUseCase
    {
        private IExpensesRepository _repository;
        private IUnitOfWork _unitOfWork;
        public DeleteExpenseUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task Execute(long id)
        {
            var result = await _repository.deletExpense(id);

            if(result == false)
            {
                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
            }
            await _unitOfWork.Commit();
        }
    }
}
