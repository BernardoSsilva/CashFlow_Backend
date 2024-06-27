﻿namespace Cashflow.Exception.exceptions
{
    public class ErrorOnValidationException:CashflowException
    {
        public List<string> Errors { get; set; }
        public ErrorOnValidationException(List<string> ErrorMessages):base(string.Empty) => Errors = ErrorMessages;
    }
}
