using Bogus;
using Cashflow.Communication.Enums;
using Cashflow.Communication.Requests.expenses;

namespace CommonTestsUtilities.Requests
{
    public class RequestRegisterExpenseJsonBuilder
    {
        public static RequestExpense Build()
        {
            var faker = new Faker();

            return new Faker<RequestExpense>()
            .RuleFor(request => request.Title, faker => faker.Commerce.Product())
            .RuleFor(request => request.Amount, faker => faker.Random.Decimal())
            .RuleFor(request => request.Date, faker => faker.Date.Past())
            .RuleFor(request => request.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(request => request.PaymentType, faker => faker.PickRandom<PaymentTypes>());
           
        }
    }
}
