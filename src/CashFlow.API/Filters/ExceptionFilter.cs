using Cashflow.Communication.exceptions;
using Cashflow.Exception;
using Cashflow.Exception.exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cashflow.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {

        // realiza chamada ao receber uma excessão
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is CashflowException)
            {
                // para erros tipados
                ThrowNewException(context);
            } else
            {
                // erros não tipados
                ThrowUnknownException(context);
            }
        }

        private void ThrowNewException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException)
            { 
                var exception = context.Exception as ErrorOnValidationException;

                var errorResponse = new ErrorMessageJson(exception.Errors);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(errorResponse);
            }
            else if (context.Exception is NotFoundException)
            {
                var errorResponse = new ErrorMessageJson(context.Exception.Message);
                context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Result = new BadRequestObjectResult(errorResponse);
            }

            else
            {
                var errorResponse = new ErrorMessageJson(context.Exception.Message);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }
        private void ThrowUnknownException(ExceptionContext context)
        {
            var errorRespone = new ErrorMessageJson(ResourceErrorMessages.UNKNOWN_ERROR);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorRespone);
        }
    }
}
