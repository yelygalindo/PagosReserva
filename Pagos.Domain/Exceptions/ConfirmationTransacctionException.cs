namespace Pagos.Domain.Exceptions
{
    public class ConfirmationTransacctionException :
        Exception
    {
        public ConfirmationTransacctionException(string reason)
            : base("La transacción no puede ser confirmada por que " + reason)
        {
        }
    }
}
