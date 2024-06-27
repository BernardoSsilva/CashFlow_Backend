namespace Cashflow.Exception.exceptions
{
    public abstract class CashflowException:SystemException
    {

        protected CashflowException(string message):base(message)
        {
            
        }
    }
}
