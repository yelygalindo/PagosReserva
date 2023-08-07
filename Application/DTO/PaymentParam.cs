namespace Application.DTO
{
    public record PaymentParam
    {
        public string Provider { get; }
        public int Amount { get; }
        public string Currency { get; }
        public string CardToken { get; }
        public string Customer { get; }

        public PaymentParam(
            string provider,
            int amount, 
            string currency, 
            string cardToken) 
        { 
            Provider = provider;
            Amount = amount;
            Currency = currency;
            CardToken = cardToken;
        }
    }
}
