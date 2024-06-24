using Cashflow.Domain.enums;

namespace Cashflow.Domain.entities
{

    public class Expense
    {
        public long id { get; set; }
        public required string title { get; set; }
        public string? description { get; set; }

        public decimal amount { get; set; }

        public DateTime date { get; set; }

        public PaymentTypes paymentType { get; set; }
    }
}