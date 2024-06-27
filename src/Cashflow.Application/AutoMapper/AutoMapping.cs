using AutoMapper;
using Cashflow.Communication.Requests.expenses;
using Cashflow.Communication.Responses.expenses;
using Cashflow.Domain.entities;

namespace Cashflow.Application.AutoMapper
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResposne();
        }

        private void RequestToEntity() {
            CreateMap<RequestExpense, Expense>();
                }
        private void EntityToResposne() {
            CreateMap<Expense, DetaildedExpenseResponse>();
            CreateMap<Expense, ShortExpenseResponse>();
        }
    }
}
