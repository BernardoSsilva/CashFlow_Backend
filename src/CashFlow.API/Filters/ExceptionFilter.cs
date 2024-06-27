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
            var cashflowException = (CashflowException)context.Exception;
            context.HttpContext.Response.StatusCode = cashflowException.statusCode;
            context.Result = new ObjectResult(cashflowException.getErrors());

           
        }
        private void ThrowUnknownException(ExceptionContext context)
        {
            var errorRespone = new ErrorMessageJson(ResourceErrorMessages.UNKNOWN_ERROR);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorRespone);
        }
    }
}
