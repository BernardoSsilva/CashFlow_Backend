using Cashflow.Communication.Enums;

namespace Cashflow.Communication.Requests.expenses
{
    public class RequestExpense
    {

        public decimal Amount { get; set; }

        public required string Title { get; set; } = string.Empty;

        public string? Description { get; set; } 

        public DateTime Date { get; set; }

        public PaymentTypes PaymentType { get; set; }

    }
}
