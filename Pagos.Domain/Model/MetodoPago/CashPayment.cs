using Pagos.Domain.ValueObjects;

namespace Pagos.Domain.Model.Items
{
    public class CashPayment : Payment
    {
        public CashPayment(int id, AmountValue amount, PaymentDate date) : base(id, amount, date)
        {
        }
    }
}
