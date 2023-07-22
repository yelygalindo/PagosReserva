using Pagos.Domain.Model.Items;
using Pagos.Domain.ValueObjects;

namespace Pagos.Domain.Factories
{
    public interface IPaymentFactory
    {
        Payment Create(int id, AmountValue amount, PaymentDate date);
    }
}
