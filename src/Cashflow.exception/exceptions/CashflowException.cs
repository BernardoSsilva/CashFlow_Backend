namespace Cashflow.Exception.exceptions
{
    public abstract class CashflowException:SystemException
    {

        protected CashflowException(string message):base(message)
        {
            
        }

        public abstract int statusCode { get;  }
        public abstract List<string> getErrors();
    }
}
