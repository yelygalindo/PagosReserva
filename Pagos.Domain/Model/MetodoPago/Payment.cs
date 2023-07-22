using Pagos.Domain.ValueObjects;
using PagosKernel.Core;

namespace Pagos.Domain.Model.Items
{
    public class Payment : AggregateRoot, IEquatable<Payment>
    {
        public int Id { get; }
        public AmountValue Amount { get; }
        public PaymentDate Date { get; }

        public Payment(int id, AmountValue amount, PaymentDate date)
        {
            Id = id;
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
            Date = date ?? throw new ArgumentNullException(nameof(date));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Payment);
        }

        public bool Equals(Payment other)
        {
            return other != null &&
                   Id == other.Id &&
                   Amount.Equals(other.Amount) &&
                   Date.Equals(other.Date);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Amount, Date);
        }
    }
}
