using Pagos.Domain.ValueObjects;

namespace Application.DTO
{
    public record PaymentResult
    {
        public string Customer { get; }
        public string ProviderName { get; }
        public string TransactionId { get; }
        public AmountValue Amount { get; }
        public bool IsSuccessfull { get; }

        public PaymentResult(
            string customer,
            string providerName,
            string transactionId,
            AmountValue amount,
            bool isSuccessfull
            )
        {
            Customer = customer;
            ProviderName = providerName;
            TransactionId = transactionId;
            Amount = amount;
            IsSuccessfull = isSuccessfull;
        }
    }
}
