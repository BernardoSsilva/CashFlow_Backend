using System.Net;

namespace Cashflow.Exception.exceptions
{
    public class ErrorOnValidationException:CashflowException
    {
        private List<string> Errors { get; set; }

        public override int statusCode => (int)HttpStatusCode.BadRequest;

        public ErrorOnValidationException(List<string> ErrorMessages):base(string.Empty) => Errors = ErrorMessages;

        public override List<string> getErrors()
        {
            return Errors;
        }
    }
}
