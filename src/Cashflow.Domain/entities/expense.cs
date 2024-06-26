using Cashflow.Domain.enums;

namespace Cashflow.Domain.entities
{

    public class Expense
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public PaymentTypes PaymentType { get; set; }
    }
}