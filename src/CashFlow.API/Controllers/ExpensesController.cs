using Cashflow.Application.UseCases.Expenses.Create;
using Cashflow.Communication.exceptions;
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
            try
            {

                CreateNewExpenseUseCase useCase = new CreateNewExpenseUseCase();
                var response = useCase.Execute(requestBody);
                return Created(string.Empty, response);


            }
            catch (ArgumentException error)
            {

                ErrorMessageJson errorResponse = new ErrorMessageJson{Message = error.Message};

                return BadRequest(errorResponse);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
        }
    }
}
