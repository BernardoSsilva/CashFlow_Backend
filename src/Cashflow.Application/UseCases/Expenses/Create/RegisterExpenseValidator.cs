using Cashflow.Communication.Requests.expenses;
using Cashflow.Exception;
using FluentValidation;
namespace Cashflow.Application.UseCases.Expenses.Create
{
    public class RegisterExpenseValidator : AbstractValidator<RequestExpense>
    {
        public RegisterExpenseValidator()
        {
            {
                RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_ERROR);
                RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_BIGGER_THAN_ZERO);
                RuleFor(expense => expense.Date).GreaterThan(DateTime.Now).WithMessage(ResourceErrorMessages.INITIAL_DATE_BEFORE_PRESENT);
                RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage(ResourceErrorMessages.UNKNOWN_PAYMENT_TYPE);
            }
        }
    }
}
