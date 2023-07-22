using Pagos.Domain.ValueObjects;

namespace Pagos.Domain.Model.Items
{
    public class CardPayment : Payment
    {
        public string CardNumber { get; }
        public string CardHolderName { get; }
        public string CardExpirationDate { get; }
        public string CardCVV { get; }

        public CardPayment(int id, AmountValue amount, PaymentDate date, string cardNumber, string cardHolderName, string cardExpirationDate, string cardCVV)
            : base(id, amount, date)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            CardExpirationDate = cardExpirationDate;
            CardCVV = cardCVV;
        }
    }
}
