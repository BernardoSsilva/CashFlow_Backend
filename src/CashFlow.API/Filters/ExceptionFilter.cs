using Cashflow.Communication.exceptions;
using Cashflow.Exception.exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Cashflow.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is CashflowException)
            {
                ThrowNewException(context);
            } else
            {

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
            else
            {
                var errorResponse = new ErrorMessageJson(context.Exception.Message);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }
        private void ThrowUnknownException(ExceptionContext context)
        {
            var errorRespone = new ErrorMessageJson("Unkwnown error");
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorRespone);
        }
    }
}
