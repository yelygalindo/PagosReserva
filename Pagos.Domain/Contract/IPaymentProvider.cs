using Pagos.Domain.Entities;

namespace Pagos.Domain.Model
{
    public interface IPaymentProvider
    {
        Transaction ProcessPayment(Transaction paymentRequest);
        Transaction ProcessRefund(Transaction request);
    }
}