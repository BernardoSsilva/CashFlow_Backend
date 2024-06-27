using AutoMapper;
using Cashflow.Application.UseCases.Expenses.Create;
using Cashflow.Application.UseCases.Expenses.UpdateExpense.interfaces;
using Cashflow.Communication.Requests.expenses;
using Cashflow.Domain.entities;
using Cashflow.Domain.Repositories;
using Cashflow.Domain.Repositories.expenses;
using Cashflow.Exception;
using Cashflow.Exception.exceptions;

namespace Cashflow.Application.UseCases.Expenses.UpdateExpense
{
    internal class UpdateExpenseUseCase : IUpdateExpenseUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpensesRepository _repository;
        private readonly IMapper _mapper;

        public UpdateExpenseUseCase(IUnitOfWork unitOfWork, IExpensesRepository repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Execute(long id, RequestExpense requestBody)
        {
            validate(requestBody);

            var expense = await _repository.getByIdToUpdate(id);
            if (expense is null)
            {
                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
            }

            _mapper.Map(requestBody, expense);
            _repository.update(expense);

           
            await _unitOfWork.Commit();
        }

        private void validate(RequestExpense requestBody)
        {
            var validator = new RegisterExpenseValidator();
            var result = validator.Validate(requestBody);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
                
        }
    }
}
