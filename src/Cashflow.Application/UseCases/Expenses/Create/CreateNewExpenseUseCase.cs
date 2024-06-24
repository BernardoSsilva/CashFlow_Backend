using Cashflow.Communication.Enums;
using Cashflow.Communication.Requests.expenses;
using Cashflow.Communication.Responses.expenses;
using Cashflow.Domain.entities;
using Cashflow.Exception.exceptions;

namespace Cashflow.Application.UseCases.Expenses.Create
{
    public class CreateNewExpenseUseCase
    {
        public CreateNewExpenseResponse Execute(RequestExpense requestBody)
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
