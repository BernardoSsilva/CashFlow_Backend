using AutoMapper;
using Cashflow.Application.UseCases.Expenses.Create.interfaces;
using Cashflow.Communication.Requests.expenses;
using Cashflow.Communication.Responses.expenses;
using Cashflow.Domain.entities;
using Cashflow.Domain.Repositories;
using Cashflow.Domain.Repositories.expenses;
using Cashflow.Exception.exceptions;

namespace Cashflow.Application.UseCases.Expenses.Create
{
    public class CreateNewExpenseUseCase: IRegisterExpenseUseCase
    {
        private readonly IExpensesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateNewExpenseUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ExpenseResponse> Execute(RequestExpense requestBody)
        {
            Validate(requestBody);
            var entity = _mapper.Map<Expense>(requestBody);

            await _repository.add(entity);
            await _unitOfWork.Commit();
            return _mapper.Map<ExpenseResponse>(entity);
        }

        // função para validação
        private void Validate(RequestExpense requestBody)
        {
            var validator = new RegisterExpenseValidator();
            var result = validator.Validate(requestBody);
            if (result.IsValid == false)
            {

                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();


                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
