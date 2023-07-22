using Pagos.Domain.Model.Items;
using Pagos.Domain.ValueObjects;

namespace Pagos.Domain.Factories
{
    public class PaymentFactory : IPaymentFactory
    {
        public Payment Create(int id, AmountValue amount, PaymentDate date)
        {
            return new Payment(id, amount, date);
        }
    }
}
