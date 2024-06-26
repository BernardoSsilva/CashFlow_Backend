using Cashflow.Application.UseCases.Expenses.Create;
using Cashflow.Application.UseCases.Expenses.Create.interfaces;
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
        public async Task<IActionResult> registerNewExpense(
            [FromServices] IRegisterExpenseUseCase useCase, 
            [FromBody] RequestExpense requestBody)
        {

           
            var response = await useCase.Execute(requestBody);
            return Created(string.Empty, response);

        }
    }
}
