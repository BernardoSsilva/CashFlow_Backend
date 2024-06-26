using Cashflow.Application.UseCases.Expenses.Create.interfaces;
using Cashflow.Communication.Enums;
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
        public CreateNewExpenseUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateNewExpenseResponse> Execute(RequestExpense requestBody)
        {
            Validate(requestBody);
            var entity = new Expense
            {
                title = requestBody.Title,
                amount = requestBody.Amount,
                description = requestBody.Description,

                date = requestBody.Date,
                paymentType = (Domain.enums.PaymentTypes)requestBody.PaymentType

            };

            await _repository.add(entity);
            await _unitOfWork.Commit();
            return new CreateNewExpenseResponse
            {
                Title = requestBody.Title,
                Description = requestBody.Description
            };
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
