namespace WebApi.Dtos
{
    public record PaymentData
    {
        public string Provider { get; init; }
        public int Amount { get; init; }
        public string Currency { get; init; }
        public string CardToken { get; init; }
        public string Customer { get; init; }

        public PaymentData(string provider, int amount, string currency, string cardToken, string customer) { 
            Provider = provider;
            Amount = amount;
            Currency = currency;
            CardToken = cardToken;
            Customer = customer;
        }
    }
}
