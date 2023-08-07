using Pagos.Domain.Entities;

namespace Pagos.Domain.Contract
{
    public interface ITransaction
    {
        Task SavePaymentRecord(Transaction paymentRecord);
    }
}
