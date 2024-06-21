using Cashflow.Communication.Enums;
using Cashflow.Communication.Requests.expenses;
using Cashflow.Communication.Responses.expenses;
using Cashflow.Exception.exceptions;

namespace Cashflow.Application.UseCases.Expenses.Create
{
    public class CreateNewExpenseUseCase
    {
        public CreateNewExpenseResponse Execute(RequestExpense requestBody)
        {
            Validate(requestBody);
            return new CreateNewExpenseResponse
            {
                Title = requestBody.Title,
                Description = requestBody.Description
            };
        }

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
