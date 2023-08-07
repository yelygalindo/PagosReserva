using Pagos.Domain.Model;
using Pagos.Domain.ValueObjects;

namespace Pagos.Domain.Entities
{
    public record Transaction
    {
        public int Id { get; }
        public string Customer { get; }       
        public string ProviderName { get; }
        public string TransactionId { get; }
        public AmountValue Amount { get;  }
        public TransactionType TransactionType { get;  }

        public string Currency;

        public string CardToken;

        public bool IsSuccessfull { get; }

        public Transaction(
            string customer,
            string providerName, 
            string transactionId, 
            AmountValue amount,
            TransactionType transactionType,
            string currency,
            string cardToken
            ) 
        { 
            Customer = customer;
            ProviderName = providerName;
            TransactionId = transactionId;
            Amount = amount;
            TransactionType = transactionType;
            Currency = currency;
            CardToken = cardToken;
        }

        public Transaction(
            int id,
            string customer,
            string providerName,
            string transactionId,
            AmountValue amount,
            TransactionType transactionType,
            bool isSuccessfull,
            string currency,
            string cardToken
            )
        {
            Id= id;
            Customer = customer;
            ProviderName = providerName;
            TransactionId = transactionId;
            Amount = amount;
            TransactionType = transactionType;
            IsSuccessfull = isSuccessfull;
            Currency = currency;
            CardToken = cardToken;
        }
    }
}