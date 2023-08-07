using Pagos.Domain.Entities;
using Pagos.Domain.Model;

namespace Pagos.Domain.Repositories
{
    public class StripePaymentProvider : IPaymentProvider
    {
        public Transaction ProcessRefund(Transaction request)
        {
            // Lógica para comunicarse con la pasarela de pago Stripe y procesar el pago.
            //var stripeCharge = StripeService.CreateRefunded(request.Amount, request.Currency, request.CardToken);
            var paymentResponse = new Transaction(request.Customer,request.ProviderName, request.TransactionId, request.Amount, request.TransactionType, request.Currency, request.CardToken);
            return paymentResponse;
        }

        public Transaction ProcessPayment(Transaction request)
        {
            var paymentResponse = new Transaction(request.Customer, request.ProviderName, request.TransactionId, request.Amount, request.TransactionType, request.Currency, request.CardToken);
            return paymentResponse;
        }
    }
}
