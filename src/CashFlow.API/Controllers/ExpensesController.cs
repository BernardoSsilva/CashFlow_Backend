using Cashflow.Application.UseCases.Expenses.Create;
using Cashflow.Application.UseCases.Expenses.Create.interfaces;
using Cashflow.Application.UseCases.Expenses.GetAll.Interfaces;
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
        [ProducesResponseType(typeof(ShortExpenseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> registerNewExpense(
            [FromServices] IRegisterExpenseUseCase useCase, 
            [FromBody] RequestExpense requestBody)
        {

           
            var response = await useCase.Execute(requestBody);
            return Created(string.Empty, response);

        }

        [HttpGet]
        [ProducesResponseType(typeof(List<MultipleExpensesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> getAllExpenses(
            [FromServices] IGetAllExpensesUseCase useCase)
        {
            var response = await useCase.Execute();
            if (response.Expenses.Count > 0)
            {
                return Ok(response);
            }

            return NoContent();

        }
    }
}
