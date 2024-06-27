using Cashflow.Application.UseCases.Expenses.Create.interfaces;
using Cashflow.Application.UseCases.Expenses.DeleteExpense.interfaces;
using Cashflow.Application.UseCases.Expenses.GetAll.Interfaces;
using Cashflow.Application.UseCases.Expenses.GetById.Interfaces;
using Cashflow.Application.UseCases.Expenses.UpdateExpense.interfaces;
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

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(List<DetaildedExpenseResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> getExpenseById(long id, [FromServices] IGetExpenseByIdUseCase useCase)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(List<DetaildedExpenseResponse>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> deleteExpense(long id, [FromServices] IDeleteExpenseUseCase useCase)
        {
            await useCase.Execute(id);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(List<DetaildedExpenseResponse>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task <IActionResult> updateExpense(long id, [FromBody] RequestExpense requestBody, [FromServices] IUpdateExpenseUseCase useCase)
        {
            await useCase.Execute(id, requestBody);
            return NoContent();
        }



    }
}
