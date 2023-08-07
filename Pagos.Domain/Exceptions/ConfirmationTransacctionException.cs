namespace Pagos.Domain.Exceptions
{
    public class ConfirmationTransacctionException : Exception
    {
        public ConfirmationTransacctionException(string reason): base("El pago no puede ser confirmada por que " + reason)
        {
        }
    }
}