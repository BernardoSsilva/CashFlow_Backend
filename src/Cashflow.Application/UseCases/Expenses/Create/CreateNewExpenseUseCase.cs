using Cashflow.Communication.Enums;
using Cashflow.Communication.Requests.expenses;
using Cashflow.Communication.Responses.expenses;

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

            if (string.IsNullOrWhiteSpace(requestBody.Title))
            {
                throw new ArgumentException("O titúlo é obrigatorio");
            }

            if (requestBody.Amount <= 0)
            {
                throw new ArgumentException("O valor deve ser maior do que 0");
            }

            if (DateTime.Compare(requestBody.Date, DateTime.UtcNow) == 1)
            {
                throw new ArgumentException("A data de inicio deve ser anterior a data atual");
            }

            if (!Enum.IsDefined(typeof(PaymentTypes), requestBody.PaymentType))
            {
                throw new ArgumentException("Este tipo de pagamento não é valido");
            }
        }
    }
}
