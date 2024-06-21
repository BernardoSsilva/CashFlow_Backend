using Cashflow.Communication.Enums;
using Cashflow.Communication.Requests.expenses;
using FluentValidation;
namespace Cashflow.Application.UseCases.Expenses.Create
{
    public class RegisterExpenseValidator : AbstractValidator<RequestExpense>
    {
        public RegisterExpenseValidator()
        {
            {
                RuleFor(expense => expense.Title).MaximumLength(255).WithMessage("O titulo deve ter até 255 caracteres");
                RuleFor(expense => expense.Title).NotEmpty().WithMessage("O titulo deve ser fornecido");
                RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("O valor deve ser maior do que 0");
                RuleFor(expense => expense.Date).LessThan(DateTime.UtcNow).WithMessage("A data de inicio deve ser anterior a data atual");
                RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("Tipo de pagamento não reconhecido");
            }
        }
    }
}
