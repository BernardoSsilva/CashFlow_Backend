using Cashflow.Communication.Enums;

namespace Cashflow.Communication.Responses.expenses
{
    public class DetaildedExpenseResponse
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public PaymentTypes PaymentType { get; set; }
    }
}
