namespace WebApi.Dtos
{
    public record RefoundData
    {        
        public string Provider { get; }
        public int Amount { get; }
        public string Currency { get; }
        public string CardToken { get; }
        public string Customer { get; }
    }
}
