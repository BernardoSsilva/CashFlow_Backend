using Cashflow.Communication.Requests.expenses;
using Cashflow.Communication.Responses.expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashflow.Application.UseCases.Expenses.Create
{
    public class CreateNewExpenseUseCase
    {
        public CreateNewExpenseResponse execute(RequestExpense requestBody)
        {
            return new CreateNewExpenseResponse
            {
                Title = requestBody.Title,
                Description = requestBody.Description
            };
        }
    }
}
