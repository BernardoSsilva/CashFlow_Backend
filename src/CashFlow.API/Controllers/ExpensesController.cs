using Cashflow.Application.UseCases.Expenses.Create;
using Cashflow.Communication.Requests.expenses;
using Cashflow.Communication.Responses.expenses;
using Microsoft.AspNetCore.Mvc;

namespace Cashflow.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(CreateNewExpenseResponse), StatusCodes.Status200OK)]
        public IActionResult registerNewExpense([FromBody] RequestExpense requestBody)
        {

            CreateNewExpenseUseCase useCase = new CreateNewExpenseUseCase();
            var response = useCase.Execute(requestBody);
            return Created(string.Empty, response);

        }
    }
}
